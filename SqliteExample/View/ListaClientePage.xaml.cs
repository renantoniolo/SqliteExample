using System;
using System.Collections.Generic;
using SqliteExample.Model;
using Xamarin.Forms;

namespace SqliteExample.View
{
    public partial class ListaClientePage : ContentPage
    {
        public ListaClientePage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            this.CarregaValuesBd();

        }

        private async void CarregaValuesBd(){

            List<TodoItem> list = await App.Database.GetItemsAsync();

            ListaCliente.ItemsSource = list;

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new CadastroPage();
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

            TodoItem todoItem = (TodoItem)e.SelectedItem;

            if (await DisplayAlert("Atenção", "Deseja excluir realmente o cliente " + todoItem.Name + "?", "Sim", "Não"))
            {
                // Exclui o item da base de dados
                var retorno = await App.Database.DeleteItemAsync(todoItem);
                // atualiza a lista
                if (retorno == 1) this.CarregaValuesBd();
            }

        }
    }
}
