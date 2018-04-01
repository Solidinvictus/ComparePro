

namespace EJ4_ParcialFinal_WPF
{
    using System;
    using System.ComponentModel;
    //NOTA: Para que me vaya acostumbrando a programar en ingles, me he propuesto hacer esta práctica en ingles

    public class Contact : INotifyPropertyChanged        //To notify our controls about changes in the properties
    {
        //Attributes 
        #region Attributes
        private int id;
        private string names;
        private string lastNames;
        private string phone;
        private string address;
        #endregion
        //Constructor
        #region Constructor
        public Contact(int id, string names, string last_names,
            string phone, string address)
        {
            this.Id = id;
            this.Names = names;
            this.LastNames = last_names;
            this.Phone = phone;
            this.Address = address;
        }
        #endregion
        //Properties
        #region Properties
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }


        public string Names
        {
            get { return names; }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("You must enter a name !");
                }

                names = value;

                OnPropertyChanged(new PropertyChangedEventArgs("Names"));
                OnPropertyChanged(new PropertyChangedEventArgs("FullName"));
            }
        }


        public string LastNames
        {
            get { return lastNames; }
            set
            {
                lastNames = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LastNames"));
                OnPropertyChanged(new PropertyChangedEventArgs("FullName"));
            }
        }


        public string Phone
        {
            get { return phone; }
            set
            {
                //Check if the number exceeds 20 digits
                if (value.Trim().Length > 20)
                {
                    throw new Exception("ERROR: The phone number exceeds 20 numbers!");
                }

                foreach (char c in value.Trim())// Recorre la cadena caracter por caracter y checa si el caracter actual es un digito.
                {
                    if (!char.IsDigit(c))// si no es un digito lanzamos excepción.
                    {
                        throw new Exception("ERROR! Phone number with invalid entries!");
                    }
                }
                phone = value;

                OnPropertyChanged(new PropertyChangedEventArgs("Phone"));
            }
        }


        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Address"));
            }
        }

        // Propiedad de solo lectura (no tiene bloque set) que vamos a mostrar en el listbox.
        public string FullName
        {
            get { return this.Names + " " + this.LastNames; }
        }

        #endregion Properties
        //Interface 
        #region Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        #endregion
    }
}
