using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExemploCTeNS
{
    public partial class FInutilizaCTe : Form
    {
        public FInutilizaCTe()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string _Ano = edAno.Text.Trim();
            string _CNPJ = edCNPJ.Text.Trim();
            string _Modelo = edModelo.Text.Trim();
            string _Serie = edSerie.Text.Trim();
            string _CTInicial = edCTInicial.Text.Trim();
            string _CTFinal = edCTFinal.Text.Trim();
            string _Justificativa = mJustificativa.Text.Trim();

            bool _valid = true;

            if (_Ano.Length <= 0)
            {
                MessageBox.Show("É obrigatório o preenchimento do ano");
                _valid = false;
            }

            if (_CNPJ.Length <= 0)
            {
                if (_valid)
                {
                    MessageBox.Show("É obrigatório o preenchimento do CNPJ");
                    _valid = false;
                }
            }

            if (_Modelo.Length <= 0)
            {
                if (_valid)
                {
                    MessageBox.Show("É obrigatório o preenchimento do modelo");
                    _valid = false;
                }
            }

            if (_Serie.Length <= 0)
            {
                if (_valid)
                {
                    MessageBox.Show("É obrigatório o preenchimento da série");
                    _valid = false;
                }
            }

            if (_CTInicial.Length <= 0)
            {
                if (_valid)
                {
                    MessageBox.Show("É obrigatório o preenchimento do CT inicial");
                    _valid = false;
                }
            }

            if (_CTFinal.Length <= 0)
            {
                if (_valid)
                {
                    MessageBox.Show("É obrigatório o preenchimento do CT final");
                    _valid = false;
                }
            }

            if (_Justificativa.Length < 15)
            {
                if (_valid)
                {
                    MessageBox.Show("A justificativa não pode ter menos que 15 caracteres");
                    _valid = false;
                }
            }

            if (_valid)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}