using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAO
{
	public class Vinyl
	{
		public static void AddVinyl(Media_Music_Vinyl Record)
		{
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					ctx.Media_Music_Vinyl.Add(Record);
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{
			}
		}

		public static void DeleteVinyl(int ID)
		{
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					Media_Music_Vinyl ItemToDelete = ctx.Media_Music_Vinyl.Single((Media_Music_Vinyl x) => x.itemNo_pk == (decimal)ID);
					bool flag = ItemToDelete != null;
					if (flag)
					{
						ctx.Media_Music_Vinyl.Remove(ItemToDelete);
						ctx.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		public static Media_Music_Vinyl GetVinyl(int ID)
		{
			Media_Music_Vinyl returnValue = new Media_Music_Vinyl();
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					returnValue = ctx.Media_Music_Vinyl.Single((Media_Music_Vinyl x) => x.itemNo_pk == (decimal)ID);
				}
			}
			catch (Exception ex)
			{
			}
			return returnValue;
		}

		public static List<Media_Music_Vinyl> SearchVinyl_NoFilter(int page)
		{
			List<Media_Music_Vinyl> returnValue = new List<Media_Music_Vinyl>();
			int RecordsToSkip = page * Constants.PAGE_SIZE;
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					returnValue = ctx.Media_Music_Vinyl.Skip(RecordsToSkip).Take(Constants.PAGE_SIZE).ToList<Media_Music_Vinyl>();
				}
			}
			catch (Exception ex)
			{
			}
			return returnValue;
		}

		public static List<Media_Music_Vinyl> SearchVinyl_Artist(string artist, int page)
		{
			List<Media_Music_Vinyl> returnValue = new List<Media_Music_Vinyl>();
			int RecordsToSkip = page * Constants.PAGE_SIZE;
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					returnValue = (from x in ctx.Media_Music_Vinyl
					where x.Artist.Contains(artist)
					select x).Skip(RecordsToSkip).Take(Constants.PAGE_SIZE).ToList<Media_Music_Vinyl>();
				}
			}
			catch (Exception ex)
			{
			}
			return returnValue;
		}

		public static List<Media_Music_Vinyl> SearchVinyl_Title(string title, int page)
		{
			List<Media_Music_Vinyl> returnValue = new List<Media_Music_Vinyl>();
			int RecordsToSkip = page * Constants.PAGE_SIZE;
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					returnValue = (from x in ctx.Media_Music_Vinyl
					where x.Title.Contains(title)
					select x).Skip(RecordsToSkip).Take(Constants.PAGE_SIZE).ToList<Media_Music_Vinyl>();
				}
			}
			catch (Exception ex)
			{
			}
			return returnValue;
		}

		public static void UpdateVinyl(Media_Music_Vinyl Record)
		{
			try
			{
				using (Media_Entity ctx = new Media_Entity())
				{
					Media_Music_Vinyl ItemToUpdate = ctx.Media_Music_Vinyl.Single((Media_Music_Vinyl x) => x.itemNo_pk == Record.itemNo_pk);
					ItemToUpdate.Artist = Record.Artist;
					ItemToUpdate.imageUrl_lg = Record.imageUrl_lg;
					ItemToUpdate.imageUrl_sm = Record.imageUrl_sm;
					ItemToUpdate.misc = Record.misc;
					ItemToUpdate.Size = Record.Size;
					ItemToUpdate.Title = Record.Title;
                    ItemToUpdate.Genre = Record.Genre;
					ctx.Entry<Media_Music_Vinyl>(ItemToUpdate).State = EntityState.Modified;
					ctx.SaveChanges();
				}
			}
			catch (Exception ex)
			{
			}
		}
	}
}
