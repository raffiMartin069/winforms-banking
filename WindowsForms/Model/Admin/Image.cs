using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Martinez_BankApp.Model.Admin
{
	public class Image
	{
        public Image(int id, byte[] imageByte)
        {
            Id = id;
			ImageByte = imageByte;
		}

        public int Id { get; private set; }
        public byte[] ImageByte { get; private set; }
    }
}
