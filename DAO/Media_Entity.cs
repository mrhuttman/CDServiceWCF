using System;
using System.Data.Entity;

namespace DAO
{
	public class Media_Entity : DbContext
	{
		public virtual DbSet<Media_Music_CDs> Media_Music_CDs
		{
			get;
			set;
		}

		public virtual DbSet<Media_Music_Vinyl> Media_Music_Vinyl
		{
			get;
			set;
		}

		public Media_Entity() : base("name=Media_Entity")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.itemNo_pk).HasPrecision(18, 0);
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.Artist).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.Title).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.imageUrl_sm).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.imageUrl_lg).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.binder).HasPrecision(18, 0);
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.numDiscs).HasPrecision(18, 0);
			modelBuilder.Entity<Media_Music_CDs>().Property((Media_Music_CDs e) => e.misc).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.itemNo_pk).HasPrecision(18, 0);
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.Artist).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.Title).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.imageUrl_sm).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.imageUrl_lg).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.Size).IsUnicode(new bool?(false));
			modelBuilder.Entity<Media_Music_Vinyl>().Property((Media_Music_Vinyl e) => e.misc).IsUnicode(new bool?(false));
		}
	}
}
