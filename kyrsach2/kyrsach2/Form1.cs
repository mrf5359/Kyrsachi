using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kyrsach2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IsMdiContainer = true;
            this.SizeChanged += Form1_SizeChanged;

        }

        private ChildForm activeChildForm;
        private int childFormCount = 0;
        private List<ChildForm> childForms = new List<ChildForm>();
        private bool isRectangleSelectionEnabled = false;
        private bool isFreeformSelectionEnabled = false;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateNewChildWindow()
        {
            ChildForm childForm = new ChildForm();
            activeChildForm = childForm;
            childForm.Text = "Дочірнє вікно " + (++childFormCount);
            childForm.MdiParent = this;
            childForm.Size = this.ClientSize;
            childForm.Show();
        }

        private void OpenImageFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.png;*.gif;*.tiff";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ChildForm activeChildForm = (ChildForm)ActiveMdiChild;
                if (activeChildForm != null)
                {
                    string filePath = openFileDialog.FileName;
                    activeChildForm.OpenImageFile(filePath);

                }
                else
                {
                    CreateNewChildWindow();
                    childForms[childForms.Count - 1].OpenImageFile(openFileDialog.FileName);
                }
            }
        }

        private void SaveImage()
        {
            ChildForm activeChildForm = (ChildForm)ActiveMdiChild;
            if (activeChildForm != null)
            {
                if (!activeChildForm.IsImageSaved && activeChildForm.IsImageModified)
                {
                    // Получаем текущий путь к файлу изображения в активном дочернем окне
                    string filePath = activeChildForm.FilePath;
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        try
                        {
                            activeChildForm.SaveImageToFile(filePath);
                            activeChildForm.IsImageSaved = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при збереженні зображення: {ex.Message}",
                                            "Помилка",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        SaveImageAs();
                    }
                }
            }
        }

        private void SaveImageAs()
        {
            ChildForm activeChildForm = (ChildForm)ActiveMdiChild;
            if (activeChildForm != null)
            {
                try
                {
                    activeChildForm.SaveImageAs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка при збереженні зображення: {ex.Message}",
                                    "Помилка",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void CloseChildWindow()
        {
            ChildForm activeChildForm = (ChildForm)ActiveMdiChild;
            if (activeChildForm != null)
            {
                if (activeChildForm.SaveChangesConfirmation())
                {
                    activeChildForm.Close();
                }
            }
        }

        private void ExitApplication()
        {
            foreach (ChildForm childForm in childForms)
            {
                if (childForm.SaveChangesConfirmation())
                {
                    childForm.Close();
                }
            }
            Application.Exit();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            foreach (ChildForm childForm in childForms)
            {
                childForm.Size = this.ClientSize; // Устанавливаем размер дочернего окна равным размеру родительского окна
                childForm.Location = new Point(0, 0); // Устанавливаем положение дочернего окна в левый верхний угол родительского окна
            }
        }

        private void CreateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CreateNewChildWindow();
        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenImageFile();
        }

        private void SaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void SaveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveImageAs();
        }

        private void CloseToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CloseChildWindow();
        }

        private void ExitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm activeChildForm = (ChildForm)ActiveMdiChild;
            if (activeChildForm != null)
            {
                // Получаем информацию о выбранном изображении из активного дочернего окна
                string fileName = activeChildForm.GetImageFileName();
                string fullPath = activeChildForm.GetImageFullPath();
                string format = activeChildForm.GetImageFormat();
                Size imageSize = activeChildForm.GetImageSize();
                float dpiX = activeChildForm.GetImageDpiX();
                float dpiY = activeChildForm.GetImageDpiY();
                float physicalWidth = activeChildForm.GetImagePhysicalWidth();
                float physicalHeight = activeChildForm.GetImagePhysicalHeight();
                PixelFormat pixelFormat = activeChildForm.GetImagePixelFormat();
                bool hasAlphaChannel = activeChildForm.HasAlphaChannel();
                int bitsPerPixel = activeChildForm.GetBitsPerPixel();

                // Выводим информацию в диалоговом окне
                string info = $"Ім’я файлу: {fileName}\n" +
                              $"Повний шлях до файлу: {fullPath}\n" +
                              $"Формат файлу: {format}\n" +
                              $"Розміри в пікселях: {imageSize.Width} x {imageSize.Height}\n" +
                              $"Вертикальна роздільна здатність: {dpiY} точок на сантиметр\n" +
                              $"Горизонтальна роздільна здатність: {dpiX} точок на сантиметр\n" +
                              $"Фізичні розміри в сантиметрах: {physicalWidth} x {physicalHeight} см\n" +
                              $"Використаний формат пікселів: {pixelFormat}\n" +
                              $"Використання біта або байта прозорості: {(hasAlphaChannel ? "Так" : "Ні")}\n" +
                              $"Кількість біт на піксель: {bitsPerPixel} біт";

                MessageBox.Show(info, "Інформація про зображення");
            }
        }

        private void imcomplemenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChildForm activeChildForm = (ChildForm)ActiveMdiChild;
            if (activeChildForm != null)
            {
                Image originalImage = activeChildForm.pictureBox.Image;
                Image complementedImage = new Bitmap(originalImage.Width, originalImage.Height);

                ChildForm childForm = new ChildForm();
                childForm.Text = "Дочірнє вікно " + (++childFormCount);
                childForm.MdiParent = this;
                childForm.Size = this.ClientSize;
                childForm.imcomplement(originalImage, complementedImage);
                childForm.Show();
            }
        }
    }

    public class ChildForm : Form
    {
        private string imagePath = "";
        private bool hasChanges = false;
        public PictureBox pictureBox;
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public bool IsImageLoaded { get; private set; }
        public bool IsImageModified { get; private set; }
        public Image Image { get; internal set; }
        public bool IsImageSaved { get { return isImageSaved; } set { isImageSaved = value; } }
        public bool isImageSaved; //  свойство для отслеживания сохраненности изображения

        public ChildForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(pictureBox);
        }

        public void OpenImageFile(string filePath)
        {
            // Загрузка изображения из файла и отображение его в PictureBox
            Image image = Image.FromFile(filePath);
            pictureBox.Image = image;

            imagePath = filePath;
            hasChanges = false;
        }

        public void SaveImage()
        {
            if (IsImageModified)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff";
                    saveFileDialog.Title = "Сохранить изображение";
                    saveFileDialog.FileName = System.IO.Path.GetFileName(FilePath);

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = saveFileDialog.FileName;
                        SaveImageToFile(FilePath);
                        IsImageModified = false;
                        IsImageSaved = true;
                    }
                }
            }
        }

        public void SaveImageAs()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff";
                saveFileDialog.Title = "Сохранить изображение как";
                saveFileDialog.FileName = System.IO.Path.GetFileName(FilePath);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = saveFileDialog.FileName;
                    SaveImageToFile(FilePath);
                    IsImageSaved = true;
                }
            }
        }

        public void SaveImageToFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && pictureBox.Image != null)
            {
                pictureBox.Image.Save(filePath);
            }
        }

        public string GetImageFileName()
        {
            return System.IO.Path.GetFileName(imagePath);
        }

        public string GetImageFullPath()
        {
            return System.IO.Path.GetFullPath(imagePath);
        }

        public string GetImageFormat()
        {
            return System.IO.Path.GetExtension(imagePath).ToUpper().TrimStart('.');
        }

        public Size GetImageSize()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return image.Size;
            }
        }

        public float GetImageDpiX()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return image.HorizontalResolution;
            }
        }

        public float GetImageDpiY()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return image.VerticalResolution;
            }
        }

        public float GetImagePhysicalWidth()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return image.PhysicalDimension.Width / image.HorizontalResolution * 2.54f;
            }
        }

        public float GetImagePhysicalHeight()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return image.PhysicalDimension.Height / image.VerticalResolution * 2.54f;
            }
        }

        public PixelFormat GetImagePixelFormat()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return image.PixelFormat;
            }
        }

        public bool HasAlphaChannel()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                PixelFormat pixelFormat = image.PixelFormat;
                return (pixelFormat & PixelFormat.Alpha) == PixelFormat.Alpha ||
                       (pixelFormat & PixelFormat.PAlpha) == PixelFormat.PAlpha;
            }
        }


        public int GetBitsPerPixel()
        {
            using (Image image = Image.FromFile(imagePath))
            {
                return Image.GetPixelFormatSize(image.PixelFormat);
            }
        }

        public void imcomplement(Image originalImage, Image complementedImage)
        {
            using (Graphics g = Graphics.FromImage(complementedImage))
            {
                g.DrawImage(originalImage, Point.Empty);
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorMatrix(new ColorMatrix(new float[][] {
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
                }));
                g.DrawImage(originalImage, new Rectangle(Point.Empty, originalImage.Size), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }

            pictureBox.Image = complementedImage;

        }

        public bool SaveChangesConfirmation()
        {
            if (hasChanges)
            {
                DialogResult result = MessageBox.Show("Зберегти зміни?", "Увага", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveImage();
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }
    }
}