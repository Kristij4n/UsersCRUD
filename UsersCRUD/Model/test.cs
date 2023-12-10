}using System;
using System.ComponentModel;

namespace UsersCRUD.Model

	//test2 for git xx
{
	public class UserDTO : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		#region Properties

		#region Id

		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; OnPropertyChanged("Id"); }
		}

		#endregion

		#region Oib

		private long oib;

		public long Oib
		{
			get { return oib; }
			set { oib = value; OnPropertyChanged("Oib"); }
		}

		#endregion

		#region Name

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; OnPropertyChanged("Name"); }
		}

		#endregion

		#region Surname

		private string surname;

		public string Surname
		{
			get { return surname; }
			set { surname = value; OnPropertyChanged("Surname"); }
		}

		#endregion

		#region City

		private string city;

		public string City
		{
			get { return city; }
			set { city = value; OnPropertyChanged("City"); }
		}

		#endregion

		#region Address

		private string address;

		public string Address
		{
			get { return address; }
			set { address = value; OnPropertyChanged("City"); }
		}

		#endregion

		#region Phone

		private long phone;

		public long Phone
		{
			get { return phone; }
			set { phone = value; OnPropertyChanged("Phone"); }
		}

		#endregion

		#region Mail

		private string mail;

		public string Mail
		{
			get { return mail; }
			set { mail = value; OnPropertyChanged("Mail"); }
		}

		#endregion

		#endregion

	}
}
