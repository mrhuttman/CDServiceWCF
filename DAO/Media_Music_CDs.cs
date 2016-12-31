using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAO
{
	[Table("Media_User.Media_Music_CDs")]
	public class Media_Music_CDs
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

		public bool? isMixed
		{
			get;
			set;
		}

		[Column(TypeName = "numeric")]
		public decimal? binder
		{
			get;
			set;
		}

		[Column(TypeName = "numeric")]
		public decimal? numDiscs
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
	}
}
