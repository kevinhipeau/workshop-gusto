using System;
using SQLite;

namespace Diabetic.Models
{
	public class DataSugar
	{
        [PrimaryKey]
        public Guid ID { get; set; }
        public double SlowSugar;
		public double FastSugar;

		public DataSugar(double slowSugar, double fastSugar)
		{
			SlowSugar = slowSugar;
			FastSugar = fastSugar;
		}

	    public DataSugar()
	    {
	        
	    }

		public void setSlowSugar(double slowSugar)
		{
			SlowSugar = slowSugar;
		}

		public void setFastSugar(double fastSugar)
		{
			FastSugar = fastSugar;
		}

		public double getSlowSugar()
		{
			return SlowSugar;
		}

		public double getFastSugar()
		{
			return FastSugar;
		}


	}
}
