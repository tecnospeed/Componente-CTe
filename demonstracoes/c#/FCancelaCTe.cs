using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExemploCTeNS
{
    public partial class FCancelaCTe : Form
    {
        public FCancelaCTe()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            string _Chave = edChave.Text.Trim();
            string _Protocolo = edNumeroProtocolo.Text.Trim();
            string _Justificativa = mJustificativa.Text.Trim();

            bool _valid = true;

            if (_Chave.Length <= 0)
            {
                MessageBox.Show("É obrigatório o preenchimento da chave");
                _valid = false;
            }

            if (_Protocolo.Length <= 0)
            {
                MessageBox.Show("É obrigatório o preenchimento do protocolo");
                _valid = false;
            }

            if (_Justificativa.Length < 15)
            {
                MessageBox.Show("A justificativa não pode ter menos que 15 caracteres");
                _valid = false;
            }

            if (_valid)
            { 
                DialogResult = DialogResult.OK;
            }
        }
    }
}