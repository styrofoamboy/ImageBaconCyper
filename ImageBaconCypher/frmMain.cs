using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageBaconCypher
{
    public partial class frmMain : Form
    {
        #region Declarations
        //***************************************************************************
        // Private Fields
        // 
        const string alphabetChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.,! ?'\"[]()-=_+abcedfghijklmnopqrstuvwxyz@#$%^&*/1234567890";
        const string identString = "ICANHAZMSG";
        Bitmap
            bmp = null;
        string
            _imgFn;
        //Dictionary<string, int>
        //    alphabet = new Dictionary<string, int>(26);
        #endregion

        #region Class Constructors
        //***************************************************************************
        // Class Constructors
        // 
        public frmMain()
        {
            InitializeComponent();

            // Initialize the alphabet lookup table.
            this.LoadAlphaLookupTable();
        }
        #endregion

        #region Private Methods
        //***************************************************************************
        // Private Methods
        // 
        private Dictionary<string, string> GetCypher(int seed, bool decrypt)
        {
            // Build the cyper based on the seed value.
            int itrCnt = (int)Math.Abs(seed.ToString().GetHashCode() / 4096);

            // Determine the cypher code for the letter "A" first.
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0;
            for (int i = 0; i < itrCnt; i++)
                this.IncrementCypherCode(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8);

            // Now build the entire cypher.
            //string[] retCypher = new string[alphabet.Count];
            string[] alphas = this.LoadAlphaLookupTable();
            Dictionary<string, string> retCypher = new Dictionary<string, string>();
            for (int i = 0; i < alphas.Length; i++)
            {
                if (!decrypt)
                    retCypher.Add(alphas[i], this.GetCypherCode(c1, c2, c3, c4, c5, c6, c7, c8));
                else
                    retCypher.Add(this.GetCypherCode(c1, c2, c3, c4, c5, c6, c7, c8), alphas[i]);
                this.IncrementCypherCode(ref c1, ref c2, ref c3, ref c4, ref c5, ref c6, ref c7, ref c8);
            }

            // And return the completed cypher to the caller.
            return retCypher;
        }
        private void IncrementCypherCode(ref int c1, ref int c2, ref int c3, ref int c4, ref int c5, ref int c6, ref int c7, ref int c8)
        {
            c8++;
            if (c8 > 1)
            { c7++; c8 = 0; }
            if (c7 > 1)
            { c6++; c7 = 0; }
            if (c6 > 1)
            { c5++; c6 = 0; }
            if (c5 > 1)
            { c4++; c5 = 0; }
            if (c4 > 1)
            { c3++; c4 = 0; }
            if (c3 > 1)
            { c2++; c3 = 0; }
            if (c2 > 1)
            { c1++; c2 = 0; }
            if (c1 > 1)
            { c8++; c1 = 0; }
        }
        private string GetCypherCode(params int[] vals)
        {
            if (vals.Length < 8)
                throw new Exception("Not enough values.");

            return GetCypherCode(vals[0], vals[1], vals[2], vals[3], vals[4], vals[5], vals[6], vals[7]);
        }
        private string GetCypherCode(int c1, int c2, int c3, int c4, int c5, int c6, int c7, int c8)
        {
            return c1.ToString() + c2.ToString() + c3.ToString() + c4.ToString() + c5.ToString() + c6.ToString() + c7.ToString() + c8.ToString();
        }
        private void UpdateCharsRemain()
        {
            this.lblHdnMsgCharRemain.Text = string.Format("Characters Remaining: {0}", this.CalcRemainChars().ToString("#,##0"));
        }
        private int CalcRemainChars()
        {
            return (this.bmp == null)
                        ? 0
                        : (int)Math.Floor(((this.bmp.Width * this.bmp.Height) - 1) / 3.0) - this.textBox1.Text.Length - identString.Length;
        }
        private string[] LoadAlphaLookupTable()
        {
            // This is a dirty way to do this, I know, but I don't really
            //   expect the alphabet to be changing anytime soon, so...
            string[] alphas = new string[alphabetChars.Length];
            for (int i = 0; i < alphabetChars.Length; i++)
                alphas[i] = alphabetChars[i].ToString();
            return alphas;
        }
        #endregion

        #region Event Handlers
        //***************************************************************************
        // Event Handlers
        // 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.bmp == null)
                return;

            #region Old Write Method
            //// The color code of the very first pixel gives of the cypher "seed".
            //int seed = bmp.GetPixel(0, 0).ToArgb();
            //Color cPwReq = bmp.GetPixel(1, 0);
            //int cPwReqR = cPwReq.R, cPwReqG = cPwReq.G, cPwReqB = cPwReq.B;
            //byte[] rsaBlob = null;
            //using (frmPw frm = new frmPw())
            //    if (frm.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(frm.Password))
            //    {
            //        seed = (seed.ToString() + frm.Password).GetHashCode();
            //        rsaBlob = System.Text.Encoding.UTF8.GetBytes(seed.ToString());
            //        if (cPwReqR % 2 != 0)
            //            if (cPwReqR < 255) cPwReqR++; else cPwReqR--;
            //        if (cPwReqG % 2 != 0)
            //            if (cPwReqG < 255) cPwReqG++; else cPwReqG--;
            //        if (cPwReqB % 2 != 0)
            //            if (cPwReqB < 255) cPwReqB++; else cPwReqB--;
            //    }

            //cPwReq = Color.FromArgb(cPwReq.A, cPwReqR, cPwReqG, cPwReqB);
            //bmp.SetPixel(1, 0, cPwReq);

            //Dictionary<string, string> cypher = this.GetCypher(seed, false);
            //string encryptString = this.textBox1.Text;

            //if (this.chkEncrypt.Checked && rsaBlob != null)
            //{
            //    System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
            //    rsa.ImportCspBlob(rsa.Encrypt(rsaBlob, true));
            //    byte[] rsaData = rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(encryptString), true);
            //    encryptString = Convert.ToBase64String(rsaData);

            //    Color cRsa = bmp.GetPixel(2, 0);
            //    int cRsaR = cRsa.R, cRsaG = cRsa.G, cRsaB = cRsa.B;
            //    if (cRsaR % 2 != 0)
            //        if (cRsaR < 255) cRsaR++; else cRsaR--;
            //    if (cRsaG % 2 != 0)
            //        if (cRsaG < 255) cRsaG++; else cRsaG--;
            //    if (cRsaB % 2 != 0)
            //        if (cRsaB < 255) cRsaB++; else cRsaB--;
            //    bmp.SetPixel(2, 0, Color.FromArgb(cRsa.A, cRsaR, cRsaG, cRsaB));
            //}
            //encryptString = identString + encryptString;

            //// Now, we're ready to embed the text as a cypher.
            //int x = 2, y = 0;
            //for (int charPos = 0; charPos < encryptString.Length; charPos++)
            //{
            //    // First, get the character at the current position of the secret string.
            //    string curChar = encryptString.Substring(charPos, 1);

            //    // Now determine the character's cypher code.
            //    string cypherCode = string.Empty;

            //    try
            //    { cypherCode = cypher[curChar]; }
            //    catch
            //    // If we don't have that character in our cypher, just ignore it.
            //    {
            //        MessageBox.Show(this, "Unable to find cypher value for character: " + curChar, "Error");
            //        return;
            //    }

            //    // Then, we set the pixels' bits to match the cypher code.
            //    for (int i = 0; i < cypherCode.Length; i += 3)
            //    {
            //        if (x++ > bmp.Width)
            //        { x = 0; y++; }
            //        if (y > bmp.Height)
            //            throw new Exception("The image is too small to contain the selected text.");

            //        // Now, get the pixel at the current position.
            //        Color cpxl = bmp.GetPixel(x, y);
            //        int r = Convert.ToInt32(cpxl.R),
            //            g = Convert.ToInt32(cpxl.G),
            //            b = Convert.ToInt32(cpxl.B);

            //        if (cypherCode.Substring(i, 1) != (r % 2).ToString())
            //            if (r < 255) r++; else r--;
            //        if (cypherCode.Substring(i + 1, 1) != (g % 2).ToString())
            //            if (g < 255) g++; else g--;
            //        if (i + 2 < cypherCode.Length)
            //        {
            //            if (cypherCode.Substring(i + 2, 1) != (b % 2).ToString())
            //                if (b < 255) b++; else b--;
            //        }
            //        else
            //            // For the "ninth" byte in the two pixels, we define whether
            //            //   or not this is the last character with an odd number
            //            //   informing the program to stop parsing.
            //            if (charPos < encryptString.Length - 1)
            //            {
            //                if ((b % 2) != 0)
            //                { if (b < 255)b++; else b--; }
            //            }
            //            else
            //            {
            //                if ((b % 2) != 1)
            //                { if (b < 255)b++; else b--; }
            //            }

            //        // Once we have the correct color values, we need to save them
            //        //   back into the image.
            //        Color nClr = Color.FromArgb(cpxl.A, r, g, b);
            //        bmp.SetPixel(x, y, nClr);
            //    }
            //}
            #endregion

            string outputFn = null;
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = ".bmp";
                dlg.Filter = "Image Files|*.bmp;*.jpg;*gif;*.png;*.jpeg;*.tiff|All Files|*.*";
                dlg.FilterIndex = 0;
                dlg.Title = "Select Image File";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    outputFn = dlg.FileName;
                }
                else
                    return;
            }
            // The color code of the very first pixel gives of the cypher "seed".
            int seed = bmp.GetPixel(0, 0).ToArgb();
            Color cPwReq = bmp.GetPixel(1, 0);
            int cPwReqR = cPwReq.R, cPwReqG = cPwReq.G, cPwReqB = cPwReq.B;
            byte[] rsaBlob = null;
            using (frmPw frm = new frmPw())
                if (frm.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(frm.Password))
                {
                    seed = (seed.ToString() + frm.Password).GetHashCode();
                    rsaBlob = System.Text.Encoding.UTF8.GetBytes(seed.ToString());
                    if (cPwReqR % 2 != 0)
                        if (cPwReqR < 255) cPwReqR++; else cPwReqR--;
                    if (cPwReqG % 2 != 0)
                        if (cPwReqG < 255) cPwReqG++; else cPwReqG--;
                    if (cPwReqB % 2 != 0)
                        if (cPwReqB < 255) cPwReqB++; else cPwReqB--;
                }

            cPwReq = Color.FromArgb(cPwReq.A, cPwReqR, cPwReqG, cPwReqB);
            bmp.SetPixel(1, 0, cPwReq);

            Dictionary<string, string> cypher = this.GetCypher(seed, false);
            string encryptString = this.textBox1.Text;

            if (this.chkEncrypt.Checked && rsaBlob != null)
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
                //rsa.ImportCspBlob(rsa.Encrypt(rsaBlob, true));
                byte[] rsaData = rsa.Encrypt(System.Text.Encoding.UTF8.GetBytes(encryptString), true);
                encryptString = Convert.ToBase64String(rsaData);

                Color cRsa = bmp.GetPixel(2, 0);
                int cRsaR = cRsa.R, cRsaG = cRsa.G, cRsaB = cRsa.B;
                if (cRsaR % 2 != 0)
                    if (cRsaR < 255) cRsaR++; else cRsaR--;
                if (cRsaG % 2 != 0)
                    if (cRsaG < 255) cRsaG++; else cRsaG--;
                if (cRsaB % 2 != 0)
                    if (cRsaB < 255) cRsaB++; else cRsaB--;
                bmp.SetPixel(2, 0, Color.FromArgb(cRsa.A, cRsaR, cRsaG, cRsaB));
            }
            encryptString = identString + encryptString;

            // Now, we're ready to embed the text as a cypher.
            int x = 2, y = 0;
            for (int charPos = 0; charPos < encryptString.Length; charPos++)
            {
                // First, get the character at the current position of the secret string.
                string curChar = encryptString.Substring(charPos, 1);

                // Now determine the character's cypher code.
                string cypherCode = string.Empty;

                try
                { cypherCode = cypher[curChar]; }
                catch
                // If we don't have that character in our cypher, just ignore it.
                {
                    MessageBox.Show(this, "Unable to find cypher value for character: " + curChar, "Error");
                    return;
                }

                // Then, we set the pixels' bits to match the cypher code.
                for (int i = 0; i < cypherCode.Length; i += 3)
                {
                    if (++x >= bmp.Width)
                    { x = 0; ++y; }
                    if (y >= bmp.Height)
                        throw new Exception("The image is too small to contain the selected text.");

                    // Now, get the pixel at the current position.
                    Color cpxl = bmp.GetPixel(x, y);
                    int r = Convert.ToInt32(cpxl.R),
                        g = Convert.ToInt32(cpxl.G),
                        b = Convert.ToInt32(cpxl.B);

                    if (cypherCode.Substring(i, 1) != (r % 2).ToString())
                        if (r < 255) r++; else r--;
                    if (cypherCode.Substring(i + 1, 1) != (g % 2).ToString())
                        if (g < 255) g++; else g--;
                    if (i + 2 < cypherCode.Length)
                    {
                        if (cypherCode.Substring(i + 2, 1) != (b % 2).ToString())
                            if (b < 255) b++; else b--;
                    }
                    else
                        // For the "ninth" byte in the two pixels, we define whether
                        //   or not this is the last character with an odd number
                        //   informing the program to stop parsing.
                        if (charPos < encryptString.Length - 1)
                        {
                            if ((b % 2) != 0)
                            { if (b < 255)b++; else b--; }
                        }
                        else
                        {
                            if ((b % 2) != 1)
                            { if (b < 255)b++; else b--; }
                        }

                    // Once we have the correct color values, we need to save them
                    //   back into the image.
                    Color nClr = Color.FromArgb(cpxl.A, r, g, b);
                    bmp.SetPixel(x, y, nClr);
                }
            }
            bmp.Save(outputFn, System.Drawing.Imaging.ImageFormat.Bmp);
        }
        private void cmdSelectSrc_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.AddExtension = true;
                dlg.DefaultExt = ".bmp";
                dlg.Filter = "Image Files|*.bmp;*.jpg;*gif;*.png;*.jpeg;*.tiff|All Files|*.*";
                dlg.FilterIndex = 0;
                dlg.Multiselect = false;
                dlg.Title = "Select Image File";
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    { this.bmp = (Bitmap)Image.FromFile(dlg.FileName); }
                    catch (Exception ex)
                    { MessageBox.Show(this, "Unable to open selected image file:\n\n" + ex.Message, "Error Reading Image"); }

                    if (this.bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed
                        || this.bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format4bppIndexed
                        || this.bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format1bppIndexed
                        || this.bmp.PixelFormat == System.Drawing.Imaging.PixelFormat.Format16bppGrayScale)
                    {
                        MessageBox.Show(this, "Cannot embed messages in grayscale or indexed color images.  Please use a different image.", "Error");
                        this.bmp.Dispose();
                        this.bmp = null;
                        return;
                    }

                    this.picSrcImage.Image = this.bmp;
                    this._imgFn = dlg.FileName;
                    this.UpdateCharsRemain();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.UpdateCharsRemain();
        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            if (this.bmp == null)
            {
                MessageBox.Show(this, "Please select an image first.", "Does not compute...", MessageBoxButtons.OK);
                this.cmdSelectSrc_Click(sender, e);
                return;
            }

            bool done = false;
            int seed = bmp.GetPixel(0, 0).ToArgb();
            Color cPwReq = bmp.GetPixel(1, 0);
            byte[] rsaBlob = null;
            if (cPwReq.R % 2 == 0 && cPwReq.G % 2 == 0 && cPwReq.B % 2 == 0)
                using (frmPw frm = new frmPw())
                    if (frm.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(frm.Password))
                    {
                        seed = (seed.ToString() + frm.Password.ToString()).GetHashCode();
                        //rsaBlob = System.Text.Encoding.UTF8.GetBytes(seed.ToString());
                    }

            Dictionary<string, string> cypher = this.GetCypher(seed, true);

            int x = 3, y = 0;
            StringBuilder identCheck = new StringBuilder();

            #region Old Read Method
            //for (int i = 0; i < identString.Length; i++)
            //{
            //    if (x++ > bmp.Width)
            //    { x = 0; y++; }
            //    Color cPxl1 = bmp.GetPixel(x, y);
            //    int r1 = Convert.ToInt32(cPxl1.R),
            //        g1 = Convert.ToInt32(cPxl1.G),
            //        b1 = Convert.ToInt32(cPxl1.B);

            //    if (x++ > bmp.Width)
            //    { x = 0; y++; }
            //    Color cPxl2 = bmp.GetPixel(x, y);
            //    int r2 = Convert.ToInt32(cPxl2.R),
            //        g2 = Convert.ToInt32(cPxl2.G),
            //        b2 = Convert.ToInt32(cPxl2.B);

            //    if (x++ > bmp.Width)
            //    { x = 0; y++; }
            //    Color cPxl3 = bmp.GetPixel(x, y);
            //    int r3 = Convert.ToInt32(cPxl3.R),
            //        g3 = Convert.ToInt32(cPxl3.G),
            //        b3 = Convert.ToInt32(cPxl3.B);

            //    int c1 = (r1 % 2),
            //        c2 = (g1 % 2),
            //        c3 = (b1 % 2),
            //        c4 = (r2 % 2),
            //        c5 = (g2 % 2),
            //        c6 = (b2 % 2),
            //        c7 = (r3 % 2),
            //        c8 = (g3 % 2),
            //        c9 = (b3 % 2);

            //    string cypherCode = GetCypherCode(c1, c2, c3, c4, c5, c6, c7, c8);
            //    try
            //    { identCheck.Append(cypher[cypherCode]); }
            //    catch
            //    { break; }
            //}
            #endregion

            string msgText = null;
            using (System.IO.FileStream fs = new System.IO.FileStream(this._imgFn, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                //int identBufferLen = (identString.Length * 9) + x;
                //byte[] fsBuffer = new byte[identBufferLen];
                //fs.Read(fsBuffer, 0, fsBuffer.Length);
                //for (int i = x; i < fsBuffer.Length; i += 9)
                //{
                //    if (i > fsBuffer.Length)
                //        throw new Exception("Key check exceeded buffer length.");

                //    int[] vals = new int[8];
                //    for (int j = 0; j < 8; j++)
                //        vals[j] = (fsBuffer[i] % 2);

                //    string cypherCode = GetCypherCode(vals);
                //    try
                //    { identCheck.Append(cypher[cypherCode]); }
                //    catch
                //    { break; }
                //    x += 9;
                //}

                for (int i = x; i < identString.Length + 3; i++)
                {
                    Color cPxl1 = bmp.GetPixel(x, y);
                    int r1 = Convert.ToInt32(cPxl1.R),
                        g1 = Convert.ToInt32(cPxl1.G),
                        b1 = Convert.ToInt32(cPxl1.B);

                    if (x++ > bmp.Width)
                    { x = 0; y++; }
                    Color cPxl2 = bmp.GetPixel(x, y);
                    int r2 = Convert.ToInt32(cPxl2.R),
                        g2 = Convert.ToInt32(cPxl2.G),
                        b2 = Convert.ToInt32(cPxl2.B);

                    if (x++ > bmp.Width)
                    { x = 0; y++; }
                    Color cPxl3 = bmp.GetPixel(x, y);
                    int r3 = Convert.ToInt32(cPxl3.R),
                        g3 = Convert.ToInt32(cPxl3.G),
                        b3 = Convert.ToInt32(cPxl3.B);

                    int c1 = (r1 % 2),
                        c2 = (g1 % 2),
                        c3 = (b1 % 2),
                        c4 = (r2 % 2),
                        c5 = (g2 % 2),
                        c6 = (b2 % 2),
                        c7 = (r3 % 2),
                        c8 = (g3 % 2),
                        c9 = (b3 % 2);

                    // Determine the bits "code value" and find the matching character in the cypher.
                    string cypherCode = GetCypherCode(c1, c2, c3, c4, c5, c6, c7, c8);
                    identCheck.Append(cypher[cypherCode]);
                }

                if (identCheck.ToString() != identString)
                {
                    MessageBox.Show(this, "No message detected.", "Sorry");
                    return;
                }

                StringBuilder sbMsg = new StringBuilder();
                x = identString.Length + 2; y = 0;
                while (!done)
                {
                    // Every three pixels contains 8 "bits" of cypher code, and the
                    //   9th byte tells us if we're done (by being an odd number).

                    if (x++ > bmp.Width)
                    { x = 0; y++; }
                    Color cPxl1 = bmp.GetPixel(x, y);
                    int r1 = Convert.ToInt32(cPxl1.R),
                        g1 = Convert.ToInt32(cPxl1.G),
                        b1 = Convert.ToInt32(cPxl1.B);

                    if (x++ > bmp.Width)
                    { x = 0; y++; }
                    Color cPxl2 = bmp.GetPixel(x, y);
                    int r2 = Convert.ToInt32(cPxl2.R),
                        g2 = Convert.ToInt32(cPxl2.G),
                        b2 = Convert.ToInt32(cPxl2.B);

                    if (x++ > bmp.Width)
                    { x = 0; y++; }
                    Color cPxl3 = bmp.GetPixel(x, y);
                    int r3 = Convert.ToInt32(cPxl3.R),
                        g3 = Convert.ToInt32(cPxl3.G),
                        b3 = Convert.ToInt32(cPxl3.B);

                    int c1 = (r1 % 2),
                        c2 = (g1 % 2),
                        c3 = (b1 % 2),
                        c4 = (r2 % 2),
                        c5 = (g2 % 2),
                        c6 = (b2 % 2),
                        c7 = (r3 % 2),
                        c8 = (g3 % 2),
                        c9 = (b3 % 2);

                    // Determine the bits "code value" and find the matching character in the cypher.
                    string cypherCode = GetCypherCode(c1, c2, c3, c4, c5, c6, c7, c8);
                    sbMsg.Append(cypher[cypherCode]);

                    // Then decide if we should keep processing based on whether the 6th bit
                    //   was divisible by 2.
                    if (c9 != 0)
                    {
                        done = true;
                        break;
                    }
                    x += 9;

                    #region New read method is wrong.  Deals with pixels as though they were one byte each and starts are wrong position.
                    //byte[] fsBufferMsg = new byte[9];
                    //fs.Read(fsBufferMsg, x, fsBufferMsg.Length);

                    //int[] vals = new int[9];
                    //for (int j = 0; j < 9; j++)
                    //    vals[j] = (fsBufferMsg[j] % 2);

                    //string cypherCode = GetCypherCode(vals);
                    //sbMsg.Append(cypher[cypherCode]);

                    //// then decide if we should keep processing based on whether the
                    ////   9th byte was divisible by 2.
                    //if (vals[8] != 0)
                    //{
                    //    done = true;
                    //    break;
                    //}
                    //x += 9;
                    #endregion
                }
                msgText = sbMsg.ToString();
            }
            Color cRsa = bmp.GetPixel(2, 0);
            if (cRsa.R % 2 == 0 && cRsa.G % 2 == 0 && cRsa.B % 2 == 0 && rsaBlob != null)
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
                //rsa.ImportCspBlob(rsa.Encrypt(rsaBlob, true));
                byte[] rsaData = rsa.Decrypt(Convert.FromBase64String(msgText), true);
                msgText = System.Text.Encoding.UTF8.GetString(rsaData);
            }

            MessageBox.Show(this, "Image Says:\n\n" + msgText, "Message");
        }
        #endregion
    }
}