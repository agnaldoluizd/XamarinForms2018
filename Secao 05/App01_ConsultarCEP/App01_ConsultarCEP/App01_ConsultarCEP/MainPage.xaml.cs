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

            if (isValidCEP(cep))
            {
                try
                {

                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço:{2} , {3} , {0} , {1} ", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                } catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }

            }
            

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length !=8) //valida se o tamanho é 8
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO ! O CEP DEVE CONTER 8 CARACTERES.", "OK");
                valido = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep,out NovoCEP)) //valida se é numerico
            {
                DisplayAlert("ERRO", "CEP INVÁLIDO ! O CEP DEVE CONTER APENAS NUMEROS.", "OK");
                valido = false;
            }

            return valido;
        }

    }
}
