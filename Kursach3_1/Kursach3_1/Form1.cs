using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Kursach3_1
{
    public partial class Form1 : Form
    {
        private readonly Mutex mutex = new Mutex();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxFilePath.Text = "";
            numericUpDownThreads.Value = Environment.ProcessorCount; // Встановлюємо кількість потоків за замовчуванням
            labelResult.Text = "";
        }

        private void buttonBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFilePath.Text = openFileDialog.FileName;
            }
        }

        private void buttonCalculate_Click_1(object sender, EventArgs e)
        {
            // Отримуємо значення байта
            byte value = (byte)numericUpDownByteValue.Value;

            // Отримуємо шлях до файлу
            string filePath = textBoxFilePath.Text;

            // Отримуємо кількість потоків
            int numThreads = (int)numericUpDownThreads.Value;

            // Очищуємо поле для результатів
            labelResult.Text = "";

            // Проводимо підрахунок байтів у файлі в окремому потоці
            Task.Run(() =>
            {
                mutex.WaitOne(); // Захоплюємо м'ютекс для взаємовиключення

                try
                {
                    Stopwatch stopwatch = new Stopwatch();

                    // Виконуємо однопоточний підрахунок байтів у файлі
                    stopwatch.Start();
                    int countSingle = ByteCounter.CountByteOccurrences(value, filePath);
                    stopwatch.Stop();
                    long singleThreadTime = stopwatch.ElapsedMilliseconds;

                    // Виконуємо багатопоточний підрахунок байтів у файлі
                    stopwatch.Restart();
                    int countParallel = ByteCounter.CountByteOccurrencesParallel(value, filePath, numThreads);
                    stopwatch.Stop();
                    long multiThreadTime = stopwatch.ElapsedMilliseconds;

                    // Оновлюємо поле для результатів
                    labelResult.Invoke((MethodInvoker)(() =>
                    {
                        labelResult.Text = $"Однопотоковий: байт {value} з'являється {countSingle} разів у файлі.\nВитрачений час: {singleThreadTime} ms\n" +
                                           $"Багатопотоковий: байт {value} з'являється {countParallel} разів у файлі.\nВитрачений час: {multiThreadTime} ms";
                    }));
                }
                catch (Exception ex)
                {
                    // Виводимо повідомлення про помилку
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mutex.ReleaseMutex(); // Звільняємо м'ютекс
                }
            });
        }

        public static class ByteCounter
        {
            public static int CountByteOccurrences(byte value, string filePath)
            {
                int count = 0;

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    int byteRead;
                    while ((byteRead = fs.ReadByte()) != -1)
                    {
                        if (byteRead == value)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }

            public static int CountByteOccurrencesParallel(byte value, string filePath, int numThreads)
            {

                long fileSize = new FileInfo(filePath).Length;
                long chunkSize = fileSize / numThreads;
                Task<int>[] tasks = new Task<int>[numThreads];

                for (int i = 0; i < numThreads; i++)
                {
                    long start = i * chunkSize;
                    long end = (i == numThreads - 1) ? fileSize : start + chunkSize;

                    tasks[i] = Task.Factory.StartNew(() => CountByteOccurrencesInRange(value, filePath, start, end));
                }

                Task.WaitAll(tasks);

                int total = 0;
                foreach (var task in tasks)
                {
                    total += task.Result;
                }

                return total;
            }

            private static int CountByteOccurrencesInRange(byte value, string filePath, long start, long end)
            {
                int count = 0;

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fs.Seek(start, SeekOrigin.Begin);
                    for (long i = start; i < end; i++)
                    {
                        int byteRead = fs.ReadByte();
                        if (byteRead == -1)
                            break;

                        if (byteRead == value)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }
    }
}
