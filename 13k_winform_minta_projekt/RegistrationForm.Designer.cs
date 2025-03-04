
namespace _13k_winform_minta_projekt
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.registration1 = new _13k_winform_minta_projekt.Registration();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registration1
            // 
            this.registration1.Location = new System.Drawing.Point(43, 32);
            this.registration1.Name = "registration1";
            this.registration1.Size = new System.Drawing.Size(354, 212);
            this.registration1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vissza";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 287);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.registration1);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Registration registration1;
        private System.Windows.Forms.Button button1;
    }
}