using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO
{
	[Table("Media_User.Media_Music_Vinyl")]
	public class Media_Music_Vinyl
	{
		[Key, Column(TypeName = "numeric")]
		public decimal itemNo_pk
		{
			get;
			set;
		}

		[StringLength(100)]
		public string Artist
		{
			get;
			set;
		}

		[StringLength(255)]
		public string Title
		{
			get;
			set;
		}

		[StringLength(255)]
		public string imageUrl_sm
		{
			get;
			set;
		}

		[StringLength(255)]
		public string imageUrl_lg
		{
			get;
			set;
		}

		[StringLength(50)]
		public string Size
		{
			get;
			set;
		}

		[StringLength(255)]
		public string misc
		{
			get;
			set;
		}

        [StringLength(255)]
        public string Genre
        {
            get;
            set;
        }
    }
}
