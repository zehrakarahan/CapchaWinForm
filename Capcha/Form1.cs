namespace Capcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == pictureBox1.Tag.ToString())
            {
                // Doğrulama başarılı
                textBox2.Text = "basarili";
            }
            else
            {
                // Doğrulama başarısız
                textBox2.Text = "basarisiz";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string captchaCode = GenerateCaptchaCode();
            pictureBox1.Image = GenerateCaptchaImage(captchaCode);
            pictureBox1.Tag = captchaCode;
        }
        private Bitmap GenerateCaptchaImage(string captchaCode)
        {
            Bitmap bitmap = new Bitmap(200, 50);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                using (Font font = new Font("Arial", 25, FontStyle.Bold))
                {
                    g.DrawString(captchaCode, font, Brushes.Gray, 2, 2);
                }
            }

            return bitmap;
        }
        private string GenerateCaptchaCode()
        {
            string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] chars = new char[5];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = allowedChars[rand.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
