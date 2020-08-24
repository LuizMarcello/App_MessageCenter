using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_MessageCenter.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExemploMessagePage : ContentPage
    {
        private List<string> _listaEventoTempo;

        private bool _assinouMensagem = false;

        public ExemploMessagePage()
        {
            InitializeComponent();
            _listaEventoTempo = new List<string>();
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            _listaEventoTempo = new List<string>();
            AtualizaLista();
        }

        private void AtualizaLista()
        {
            lvwEventos.ItemsSource = new ObservableCollection<string>(_listaEventoTempo);
        }

        private void btnPublicar_Clicked(object sender, EventArgs e)
        {
            //Publicando a mensagem(método "Send()")
            //(quem é o remetente(que publica),string label que identifica a mensagem, informação a ser passada)
            MessagingCenter.Send(this, "datahora", DateTime.Now);
        }

        private void btnSubscrever_Clicked(object sender, EventArgs e)
        {
            _assinouMensagem = !_assinouMensagem;

            if (_assinouMensagem)
            {
                btnSubscrever.Text = "Cancelar Assinatura";

                //Assinando a mensagem(método "Subscribe()")
                //(quem vai assinar,string etiqueta da mensagem)
                //<remetente da mensagem(própria página),um argumento(a mansagem)>
                MessagingCenter.Subscribe<ExemploMessagePage, DateTime>(this, "datahora",
                    (pagina, hora) =>
                    {
                        _listaEventoTempo.Add(hora.ToString());
                        AtualizaLista();
                    });
            }
            else
            {
                //Cancelando a assinatura(Método "Unsubscribe()")
                //<Quem tá cancelando a assinatura(própria página), um argumento(a mensagem)>
                MessagingCenter.Unsubscribe<ExemploMessagePage, DateTime>(this, "datahora");
            }
        }


    }
}