using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GSB
{
    public partial class FrmPresentation : Form
    {
        public FrmPresentation()
        {
            InitializeComponent();
        }


        #region procédures événementielles

        private void FrmPresentation_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirDgvPresentation();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // effacer les messages d'erreur précédents
           dgvPresentation.ClearSelection();
           

            // contrôle des données saisies
           dgvPresentation
            


            // Ajouter la présentation

        }
        #endregion


        #region méthodes


        private void parametrerComposant()
        {
            // titre du formulaire
            this.Text = "Ajout présentation";

            // le formulaire doit occuper la totalité de l'écran
            this.WindowState = FormWindowState.Maximized;

            parametrerDgv(dgvPresentation);
        }


        private void parametrerDgv(DataGridView dgv) {
            #region paramètrage au niveau du composant

            // accessibilité du composant
            dgv.Enabled = true;

            // permissions
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowDrop = false;
            dgv.AllowUserToOrderColumns = false;

            // largeur du composant non définie car mode Fill
            dgv.Width = 902;
            // dgv.Dock = DockStyle.Fill;

            //  bordures extérieures
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // Bordure au niveau des cellules
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Couleur de fond 
            dgv.BackgroundColor = Color.White;

            // Couleur de texte  
            dgv.ForeColor = Color.Black;

            // Mode de sélection : FullRowSelect, CellSelect ...
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // sélection multiple 
            dgv.MultiSelect = false;

            // Police de caractère des cellules
            dgv.DefaultCellStyle.Font = new Font("Georgia", 10);


            // L'utilisateur peut-il modifier le contenu des cellules ou est-elle réservée à la programmation ?
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;

            #endregion

            #region paramètrage des lignes

            // Hauteur 
            dgv.RowTemplate.Height = 30;

            // Entête de chaque ligne : visibilité et bordure 
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // couleur du texte
            dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            // style de bordure 
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // couleur de fond, ne pas utiliser transparent car la couleur de la ligne sélectionnée restera après sélection
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Couleur alternative appliquée une ligne sur deux
            // dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238);

            // Couleur de fond de la ligne sélectionnée : mettre la même que les cellules si on ne veut pas mettre la zone en évidence 
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region paramétrage des colonnes

            // Nombre de colonne sans compter les colonnes ajoutées par la méthode Add
            dgv.ColumnCount = 2;

            // Entête des colonnes : visibilité, hauteur et style des bordure 
            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // style  [à adapter] (ici : noir sur fond transparent sans mise en évidence de la sélection)
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;    // même couleur que backColor pour ne pas mettre en évidence la colonne sélectionnée
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);

            // définition de l'ajustement de la taille des colonnes (Fill, AllCells …) 
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            #endregion

            #region Définition du contenu des colonnes

            dgv.Columns[0].Name = "Date Présentation";
            dgv.Columns[0].Width = 150;

            dgv.Columns[1].Name = "Sujet";
            dgv.Columns[1].Width = 750;
            dgv.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;




            #endregion
        }

        private void remplirDgvPresentation() {
        }

        #endregion
    }
}
