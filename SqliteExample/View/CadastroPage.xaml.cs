using System;
using System.Collections.Generic;
using SqliteExample.Model;
using Xamarin.Forms;

namespace SqliteExample.View
{
    public partial class CadastroPage : ContentPage
    {

        public CadastroPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {

            if (!String.IsNullOrEmpty(xEmail.Text) && !String.IsNullOrEmpty(xNome.Text))
            {

                TodoItem todoItem = new TodoItem();

                // pego os valores da interface
                todoItem.Email = xEmail.Text;
                todoItem.Name = xNome.Text;
                todoItem.Age = (int)xAge.Value;

                int retorno  = await App.Database.SaveItemAsync(todoItem);

                // gravou correto an base?
                if (retorno == 1)
                {
                    await DisplayAlert("Atenção", todoItem.Name + " foi salvo com sucesso.", "OK");
                    this.ClickReturn();
                }
            }
            else{ // preencha corretamanete os dados
                await DisplayAlert("Atenção", "Por favor, informe um Nome e E-mail válidos.", "OK");
            }

        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            this.ClickReturn();
        }

        private void ClickReturn(){
            // retorna para Lista de Clientes
            Application.Current.MainPage = new ListaClientePage();
        }
    }
}
