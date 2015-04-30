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

        public static Rectangle MeasureCharacterSize(char character, Font font, PixelFormat pixelFormat, TextRenderingHint trh)
        {
            var characterToDraw = character == ' ' ? "_ _" : character.ToString();
            var size = TextRenderer.MeasureText(characterToDraw, font);

            using (Bitmap bitmap = new Bitmap(size.Width, size.Height, pixelFormat))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.TextRenderingHint = trh;
                    graphics.Clear(Color.Transparent);
                    graphics.DrawString(characterToDraw, font, new SolidBrush(Color.Black), new PointF(0, 0));
                }

                var paddingLeft = -1;
                var paddingRight = -1;

                if (character != ' ')
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        for (var y = 0; y < bitmap.Height; y++)
                        {
                            var rightX = bitmap.Width - 1 - x;
                            if (paddingLeft == -1 && bitmap.GetPixel(x, y).A != 0)
                                paddingLeft = x;
                            if (paddingRight == -1 && bitmap.GetPixel(rightX, y).A != 0)
                                paddingRight = rightX;

                            if (paddingLeft != -1 && paddingRight != -1)
                            {
                                var width = paddingRight - paddingLeft + 1;
                                return new Rectangle(paddingLeft, 0, width, size.Height);
                            }
                        }
                    }
                }
                else
                {
                    var dashFound = false;
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        for (var y = 0; y < bitmap.Height; y++)
                        {
                            if (dashFound && paddingLeft != -1 && bitmap.GetPixel(x, y).A != 0)
                            {
                                var spaceSize = TextRenderer.MeasureText(" ", font);
                                paddingRight = x;
                                return new Rectangle(0, 0, paddingRight - paddingLeft, spaceSize.Height);
                            }

                            if (bitmap.GetPixel(x, y).A != 0)
                            {
                                dashFound = true;
                                break;
                            }

                            if (dashFound && paddingLeft == -1 && y == bitmap.Height - 1)
                                paddingLeft = x;
                        }
                    }
                }

                return new Rectangle(0, 0, size.Width, size.Height);
            }
        }

        public static Bitmap GenerateFontMap(string fontFamily, int fontSize, FontStyle fontStyle, Color fontColor, Color backColor, TextRenderingHint textRenderingHint, string characters, int bitmapWidth, int bitmapHeight, int paddingLeft, int paddingRight, bool drawGrid, out string code)
        {
            PointF location = new PointF(0f, 0f);
            StringBuilder codeBuilder = new StringBuilder();
            Dictionary<int, Rectangle> charsInfo = new Dictionary<int, Rectangle>();

            var maxCharVal = 0;

            Bitmap bitmap = new Bitmap(bitmapWidth, bitmapHeight, PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.TextRenderingHint = textRenderingHint;
                var maxCharHeight = 0;

                graphics.Clear(backColor);

                using (Font font = new Font(fontFamily, fontSize, fontStyle))
                {
                    for (var i = 0; i < characters.Length; i++)
                    {
                        var charVal = (int)characters[i];

                        if (charVal > maxCharVal)
                            maxCharVal = charVal;

                        var size = MeasureCharacterSize(characters[i], font, bitmap.PixelFormat, graphics.TextRenderingHint); 

                        //TextRenderer.DrawText(graphics, characterToDraw, arialFont, new Point((int)location.X, (int)location.Y), Color.White);
                        graphics.DrawString(characters[i].ToString(), font, new SolidBrush(fontColor), new PointF(location.X - size.X + paddingLeft, location.Y));

                        var charRect = new Rectangle((int)location.X, (int)location.Y, (int)size.Width + paddingLeft + paddingRight, (int)size.Height);

                        if (drawGrid)
                            graphics.DrawRectangle(new Pen(Color.FromArgb((byte)~backColor.R, (byte)~backColor.G, (byte)~backColor.B)), charRect);

                        charsInfo.Add(charVal, charRect);

                        location.X += charRect.Width;

                        if (charRect.Height > maxCharHeight)
                            maxCharHeight = (int)charRect.Height;

                        if (i < characters.Length - 1)
                        {
                            if ((location.X + MeasureCharacterSize(characters[i + 1], font, bitmap.PixelFormat, graphics.TextRenderingHint).Width + paddingLeft + paddingRight) > bitmapWidth)
                            {
                                location.X = 0;
                                location.Y += maxCharHeight+1;
                                maxCharHeight = 0;
                            }
                        }
                    }
                }
            }

            var breakCounter = 0;

            codeBuilder.AppendFormat("const u16 {{0}}_width = {0};\r\n", bitmap.Width);
            codeBuilder.AppendFormat("const u16 {{0}}_height = {0};\r\n", bitmap.Height); 
            codeBuilder.AppendFormat("const Rect {{0}}[{0}] = {{{{", maxCharVal + 1);
            for (var i = 0; i <= maxCharVal; i++)
            {

                if (i > 0)
                    codeBuilder.Append(",");

                if (charsInfo.ContainsKey(i))
                    codeBuilder.AppendFormat("{{{{{0},{1},{2},{3}}}}}", charsInfo[i].X, charsInfo[i].Y, charsInfo[i].Width, charsInfo[i].Height);
                else
                    codeBuilder.Append("{{0,0,0,0}}");

                breakCounter++;

                if (breakCounter == 4)
                {
                    codeBuilder.AppendLine();
                    breakCounter = 0;
                }
            }
            codeBuilder.Append("}};");

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

                var bitmap = GenerateFontMap(cmbFontFamily.Text, (int)nudFontSize.Value, 
                    fontStyle, _currentForeColor, _currentBackColor, 
                    TextRenderingHint.SingleBitPerPixel, txtCharacterSet.Text, 
                    (int)nudBitmapWidth.Value, (int)nudBitmapHeight.Value, 
                    (int)nudPaddingLeft.Value, (int)nudPaddingRight.Value, 
                    true, out _cCode);

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

        public static string GetFilename(string fontFamily, FontStyle fontStyle, int fontSize, Color fontColor)
        {
            var fontStyleStr = string.Empty;
            if (fontStyle == FontStyle.Italic) fontStyleStr = "italic";
            else if (fontStyle == FontStyle.Bold) fontStyleStr = "bold";

            return (fontFamily + fontSize + "_" +
                    fontColor.R.ToString("x").PadLeft(2, '0') +
                    fontColor.G.ToString("x").PadLeft(2, '0') +
                    fontColor.B.ToString("x").PadLeft(2, '0') +
                    (!string.IsNullOrEmpty(fontStyleStr) ? ("_" + fontStyleStr) : string.Empty)
                    ).ToLower().Replace(" ", "");
        }

        private void SaveImage(string filename, bool saveAsTBPNG)
        {
            var fontStyle = FontStyle.Regular;
            fontStyle = (chkFontStyleItalic.Checked ? FontStyle.Italic : FontStyle.Regular) | (chkFontStyleBold.Checked ? FontStyle.Bold : FontStyle.Regular);
            using(Bitmap bitmap = GenerateFontMap(cmbFontFamily.Text, (int)nudFontSize.Value, fontStyle,
                _currentForeColor, saveAsTBPNG ? Color.Transparent : _currentBackColor,
                saveAsTBPNG ? TextRenderingHint.AntiAlias : TextRenderingHint.SingleBitPerPixel, 
                txtCharacterSet.Text, (int)nudBitmapWidth.Value, (int)nudBitmapHeight.Value, 
                (int)nudPaddingLeft.Value, (int)nudPaddingRight.Value, false, out _cCode))
            {
                bitmap.Save(filename, saveAsTBPNG ? ImageFormat.Png : ImageFormat.Bmp);
            }
        }

        private FontStyle GetSelectedFontStyle()
        {
            var fontStyle = FontStyle.Regular;

            if (chkFontStyleItalic.Checked || chkFontStyleBold.Checked)
                fontStyle = (chkFontStyleItalic.Checked ? FontStyle.Italic : 0) | (chkFontStyleBold.Checked ? FontStyle.Bold : 0);
            return fontStyle;
        }

        private void saveTransparentBackgroundPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG Files (.png)|*.png";
            dialog.FileName = GetFilename(cmbFontFamily.Text, GetSelectedFontStyle(), (int)nudFontSize.Value, _currentForeColor) + ".png";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                SaveImage(dialog.FileName, true);
            
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Bitmap Files (.bmp)|*.bmp";
            dialog.FileName = GetFilename(cmbFontFamily.Text, GetSelectedFontStyle(), (int)nudFontSize.Value, _currentForeColor) + ".bmp";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                SaveImage(dialog.FileName, false);
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "C/C++ Header File (.h)|*.h";
            dialog.FileName = GetFilename(cmbFontFamily.Text, GetSelectedFontStyle(), (int)nudFontSize.Value, _currentForeColor) + ".h";

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                File.WriteAllText(dialog.FileName, string.Format(_cCode, Path.GetFileNameWithoutExtension(dialog.FileName).Replace(" ", "_") ));
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




  

 