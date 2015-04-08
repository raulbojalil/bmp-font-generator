using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace BMPFontGenerator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private string _cCode = string.Empty;
        private Color _currentForeColor = Color.White;
        private Color _currentBackColor = Color.Magenta;
        private MagnifyingGlassForm _mglass = null;

        public Bitmap GenerateFontMap(string fontFamily, int fontSize, FontStyle fontStyle, Color fontColor, Color backColor, string characters, int bitmapWidth, int bitmapHeight, int paddingLeft, int paddingRight, bool drawGrid, out string code)
        {
            PointF location = new PointF(0f, 0f);
            StringBuilder codeBuilder = new StringBuilder();
            Dictionary<int, Rectangle> charsInfo = new Dictionary<int, Rectangle>();

            var maxCharVal = 0;

            Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                var maxCharHeight = 0;
                graphics.Clear(backColor);

                using (Font arialFont = new Font(fontFamily, fontSize, fontStyle))
                {
                    for (var i = 0; i < characters.Length; i++)
                    {
                        var charVal = (int)characters[i];

                        if (charVal > maxCharVal)
                            maxCharVal = charVal;

                        var characterToDraw = "" + characters[i];
                        var size = TextRenderer.MeasureText(characterToDraw, arialFont);
                        size.Width += paddingRight;

                        //TextRenderer.DrawText(graphics, characterToDraw, arialFont, new Point((int)location.X, (int)location.Y), Color.White);
                        graphics.DrawString(characterToDraw, arialFont, new SolidBrush(fontColor), new PointF(location.X + paddingLeft, location.Y));

                        var rect = new Rectangle((int)location.X, (int)location.Y, (int)size.Width, (int)size.Height);

                        if (drawGrid)
                            graphics.DrawRectangle(new Pen(Color.FromArgb((byte)~backColor.R, (byte)~backColor.G, (byte)~backColor.B)), rect);

                        charsInfo.Add(charVal, rect);

                        location.X += size.Width;

                        if (size.Height > maxCharHeight)
                            maxCharHeight = (int)size.Height;

                        if (i < characters.Length - 1)
                        {
                            if ((location.X + graphics.MeasureString(characters[i + 1].ToString(), arialFont).Width) > bitmapWidth)
                            {
                                location.X = 0;
                                location.Y += maxCharHeight;
                                maxCharHeight = 0;
                            }
                        }
                    }
                }
            }


            var breakCounter = 0;

            codeBuilder.AppendFormat("const Rect [VAR_NAME][{0}] = {{", maxCharVal + 1);
            for (var i = 0; i <= maxCharVal; i++)
            {

                if (i > 0)
                    codeBuilder.Append(",");

                if (charsInfo.ContainsKey(i))
                    codeBuilder.AppendFormat("{{{0},{1},{2},{3}}}", charsInfo[i].X, charsInfo[i].Y, charsInfo[i].Width, charsInfo[i].Height);
                else
                    codeBuilder.Append("{0,0,0,0}");

                breakCounter++;

                if (breakCounter == 4)
                {
                    codeBuilder.AppendLine();
                    breakCounter = 0;
                }
            }
            codeBuilder.Append("};");

            code = codeBuilder.ToString();
            return bitmap;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            _mglass = new MagnifyingGlassForm();
            _mglass.Show();
            _mglass.StartPosition = FormStartPosition.CenterScreen;

            btnBackColor.BackColor = _currentBackColor;
            btnForeColor.BackColor = _currentForeColor;
            btnBackColor.Text = ("#" + _currentBackColor.R.ToString("x").PadLeft(2, '0') + _currentBackColor.G.ToString("x").PadLeft(2, '0') + _currentBackColor.B.ToString("x").PadLeft(2, '0')).ToUpper();
            btnForeColor.Text = ("#" + _currentForeColor.R.ToString("x").PadLeft(2, '0') + _currentForeColor.G.ToString("x").PadLeft(2, '0') + _currentForeColor.B.ToString("x").PadLeft(2, '0')).ToUpper();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                cmbFontFamily.Items.Add(font.Name);
            }

            RefreshFontMap(null, null);
        }

        private void RefreshFontMap(object sender, EventArgs e)
        {
            try
            {
                var fontStyle = FontStyle.Regular;
                fontStyle = (chkFontStyleItalic.Checked ? FontStyle.Italic : FontStyle.Regular) | (chkFontStyleBold.Checked ? FontStyle.Bold : FontStyle.Regular);

                var bitmap = GenerateFontMap(cmbFontFamily.Text, (int)nudFontSize.Value, fontStyle, _currentForeColor, _currentBackColor, txtCharacterSet.Text, (int)nudBitmapWidth.Value, (int)nudBitmapHeight.Value, (int)nudPaddingLeft.Value, (int)nudPaddingRight.Value, true, out _cCode);
                pictureBox1.Image = bitmap;
                Bitmap resized = new Bitmap(bitmap, bitmap.Width * 4, bitmap.Height * 4);

                /*
                using (var graph = Graphics.FromImage(resized))
                {
                    // uncomment for higher quality output
                    graph.InterpolationMode = InterpolationMode.High;
                    graph.CompositingQuality = CompositingQuality.HighQuality;
                    graph.SmoothingMode = SmoothingMode.HighQuality;

                    var scaleWidth = (int)(resized.Width * 4);
                    var scaleHeight = (int)(resized.Height * 4);

                    graph.DrawImage(bitmap, new Rectangle(((int)resized.Width - scaleWidth) / 2, ((int)resized.Height - scaleHeight) / 2, scaleWidth, scaleHeight));
                }*/

                _mglass.SetImage(resized);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFontFamily.Text = "Arial";
                RefreshFontMap(sender, e);
            }
        }

        private string GetFilename()
        {
            return (cmbFontFamily.Text + nudFontSize.Value + "_" + _currentForeColor.R.ToString("x").PadLeft(2, '0') + _currentForeColor.G.ToString("x").PadLeft(2, '0') + _currentForeColor.B.ToString("x").PadLeft(2, '0')).ToLower().Replace(" ", "");
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Bitmap Files (.bmp)|*.bmp";
            dialog.FileName = GetFilename() + ".bmp";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //GenerateFontMap(cmbFontFamily.Text, (int)nudFontSize.Value, _currentColor, txtCharacters.Text, 256, 256, -2, -5, false, out _cCode).Save(dialog.FileName, ImageFormat.Bmp);
                //pictureBox1.Image.Save(dialog.FileName, ImageFormat.Bmp);
                var fontStyle = FontStyle.Regular;
                fontStyle = (chkFontStyleItalic.Checked ? FontStyle.Italic : FontStyle.Regular) | (chkFontStyleBold.Checked ? FontStyle.Bold : FontStyle.Regular);
                var bitmap = GenerateFontMap(cmbFontFamily.Text, (int)nudFontSize.Value, fontStyle, _currentForeColor, _currentBackColor, txtCharacterSet.Text, (int)nudBitmapWidth.Value, (int)nudBitmapHeight.Value, (int)nudPaddingLeft.Value, (int)nudPaddingRight.Value, false, out _cCode);
                bitmap.Save(dialog.FileName, ImageFormat.Bmp);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "C Header File (.h)|*.h";
            dialog.FileName = GetFilename() + ".h";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, _cCode.Replace("[VAR_NAME]", Path.GetFileNameWithoutExtension(dialog.FileName).Replace(" ", "_")));
            }
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = _currentForeColor;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _currentForeColor = dialog.Color;
                btnForeColor.Text = ("#" + _currentForeColor.R.ToString("x").PadLeft(2, '0') + _currentForeColor.G.ToString("x").PadLeft(2, '0') + _currentForeColor.B.ToString("x").PadLeft(2, '0')).ToUpper();
                btnForeColor.BackColor = dialog.Color;
            }
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = _currentBackColor;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _currentBackColor = dialog.Color;
                btnBackColor.Text = ("#" + _currentBackColor.R.ToString("x").PadLeft(2, '0') + _currentBackColor.G.ToString("x").PadLeft(2, '0') + _currentBackColor.B.ToString("x").PadLeft(2, '0')).ToUpper();
                btnBackColor.BackColor = dialog.Color;
            }
        }

        private void txtCharacters_TextChanged(object sender, EventArgs e)
        {
            var selectionStartPos = txtCharacterSet.SelectionStart;
            var text = txtCharacterSet.Text;
            var initialTextLength = text.Length;

            for (var i = 0; i < text.Length; i++)
            {
                var ch1 = text[i];

                for (var j = 0; j < text.Length; j++)
                {
                    if (i != j)
                    {
                        var ch2 = text[j];

                        if (ch1 == ch2)
                        {
                            text = text.Remove(j, 1);
                            i--;
                            j--;
                        }
                    }
                }
            }

            if (text.Length < initialTextLength)
            {
                MessageBox.Show("Please specify unique characters in the charset field.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCharacterSet.Text = text;
                txtCharacterSet.Focus();
                if (txtCharacterSet.Text.Length > 0)
                {
                    txtCharacterSet.SelectionStart = selectionStartPos;
                    txtCharacterSet.SelectionLength = 0;
                }
            }
            else
                RefreshFontMap(sender, e);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _mglass.SetImageLocation(new Point(-(e.Location.X * 4) + (pictureBox1.Image.Width / 2), -(e.Location.Y * 4) + (pictureBox1.Image.Height / 2)));
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            //_mglass.Location = new Point(-9999, -9999);
        }
    }

}




  

 