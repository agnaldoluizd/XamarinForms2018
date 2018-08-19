using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }
        private void BuscarCEP(object sender, EventArgs args)
        {
            // TODO - Logica do programa.

            // TODO - Validaçoes.

            string cep = CEP.Text.Trim(); //recebe o que o usuario digitou CEP.text
            Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

            RESULTADO.Text = string.Format("Endereço:{2} de {3}  {0} , {1} ", end.localidade, end.uf, end.logradouro,end.bairro);
            
        }

    }
}
