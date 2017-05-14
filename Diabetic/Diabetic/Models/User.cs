using System;
using SQLite;

namespace Diabetic.Models
{
	public class User
	{
        [PrimaryKey]
        public Guid ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		Gender Sex { get; set; }
        public double SlowSugarMorning { get; set; }
        public double FastSugarMorning { get; set; }
        public double SlowSugarLaunch { get; set; }
        public double FastSugarLaunch { get; set; }
        public double SlowSugarAfter { get; set; }
        public double FastSugarAfter { get; set; }
        public double SlowSugarEve { get; set; }
        public double FastSugarEve { get; set; }



        public User(string firstName, string lastName, DateTime birthDate, Gender sex) 
		{
			ID = Guid.NewGuid();
			FirstName = firstName;
			LastName = lastName;
			BirthDate = birthDate;
			Sex = sex;
	
		}

	    public User()
	    {
	        
	    }

	}
}
