using System;
using System.Collections.ObjectModel;


namespace EJ4_ParcialFinal_WPF
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    public partial class WindowContacts : Window
    {
        private ObservableCollection<Contact> ListContacts;

        public WindowContacts()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ListContacts = App.DataControl.getContacts();
                listContacts.ItemsSource = ListContacts; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private enum EditMode
        {
            Insert,
            Change
        };

        private EditMode edit;

        private void EditModeWin()
        {
            listContacts.IsEnabled = false;
            ugNewModErase.IsEnabled = false;

            if (edit == EditMode.Insert)
            {
                btnGuardar.IsEnabled = true;

            }
            else
            {
                if (edit == EditMode.Change)
                {
                    btnActualizar.IsEnabled = true;
                }
            }

            btnCancelar.IsEnabled = true;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(gContactsDetails); i++)
            {
                if (VisualTreeHelper.GetChild(gContactsDetails, i).GetType() == typeof(TextBox))
                {
                    TextBox txtb = (TextBox)VisualTreeHelper.GetChild(gContactsDetails, i);
                    if (txtb.Name != "txtId")
                    {
                        txtb.IsReadOnly = false;
                    }                 
                }
            }
        }

        private void NormalWinMode()
        {
            listContacts.IsEnabled = true;
            ugNewModErase.IsEnabled = true;

            if (edit == EditMode.Insert)
            {
                btnGuardar.IsEnabled = false;
            }
            else
            {
                if (edit == EditMode.Change)
                {
                    btnActualizar.IsEnabled = false;
                }
            }

            btnCancelar.IsEnabled = false;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(gContactsDetails); i++)
            {
                if (VisualTreeHelper.GetChild(gContactsDetails, i).GetType() == typeof(TextBox))
                {
                    TextBox txtbox = (TextBox)VisualTreeHelper.GetChild(gContactsDetails, i);
                    if (txtbox.Name != "txtId")
                    {
                        txtbox.IsReadOnly = true;
                    }                 
                }
            }
        }

        private void ClearTxtB()
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(gContactsDetails); i++)
            {
                if (VisualTreeHelper.GetChild(gContactsDetails, i).GetType() == typeof(TextBox))
                {
                    ((TextBox)VisualTreeHelper.GetChild(gContactsDetails, i)).Clear();
                }
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            listContacts.SelectedItem = null;
            edit = EditMode.Insert;
            EditModeWin();
            FocusManager.SetFocusedElement(this, txtNombres);
        }

        
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (listContacts.Items.Count > 0)
            {
                if (listContacts.SelectedItem != null)
                {
                    edit = EditMode.Change;
                    EditModeWin();
                    FocusManager.SetFocusedElement(this, txtNombres);
                }
                else
                {
                    MessageBox.Show("You must make a selection !",
                        "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Currently no contact are registred",
                    "Inf", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

       
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (listContacts.Items.Count > 0)
            {
                if (listContacts.SelectedItem != null)
                {
                    if (MessageBox.Show("Are you sure deleting contact?",
                        "Confirm", MessageBoxButton.YesNo,
                        MessageBoxImage.Warning) == MessageBoxResult.Yes) 
                    {

                        int res = 0;

                        try
                        {
                            res =
                                App.DataControl.Erase
                                (((Contact)listContacts.SelectedItem).Id);
                                                    
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        if (res > 0)
                        {
                            ListContacts.Remove((Contact)listContacts.SelectedItem);
                          
                        }
                        else 
                        {
                            ClearTxtB();
                            listContacts.SelectedItem = null;
                        }
                    }
                }

                else 
                {
                    MessageBox.Show("You must make a selection",
                        "Deleting contact", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            else 
            {
                MessageBox.Show("No contacts registred currently!",
                    "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Contact contact;

            int id = -1;

            try
            {
                contact = new Contact(-1, txtNombres.Text.Trim(), txtApellidos.Text.Trim(),
                        txtTelefono.Text.Trim(), txtDireccion.Text.Trim());

                id = App.DataControl.Save(contact);               

                if (id > 0) 
                {
                    MessageBox.Show("Contact saved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    contact.Id = id;
                    ListContacts.Add(contact); 
                    listContacts.SelectedItem = contact; 
                    listContacts.ScrollIntoView(contact);
                    FocusManager.SetFocusedElement(this, listContacts);                    
                    NormalWinMode();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contact cont;
                cont = (Contact)listContacts.SelectedItem;
                cont.Names = txtNombres.Text;
                cont.LastNames = txtApellidos.Text;
                cont.Phone = txtTelefono.Text;
                cont.Address = txtDireccion.Text;

                int res = 0;
              
                res = App.DataControl.Update(cont.Id, txtNombres.Text,
                    txtApellidos.Text, txtTelefono.Text, txtDireccion.Text);
                
                if (res > 0) 
                {
                    MessageBox.Show("Contact modified successfuly", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    FocusManager.SetFocusedElement(this, listContacts);
                    listContacts.ScrollIntoView(cont);
                    NormalWinMode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            listContacts.SelectedItem = null;
            ClearTxtB();
            NormalWinMode();
        }
    }
}
