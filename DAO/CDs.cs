using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
//using System.Diagnostics;
using System.IO;
using System.Text;
using CDServiceWCF.Entity;

namespace DAO
{
	public class CDs
	{
		public static int AddCD(Media_Music_CDs CD)
		{            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***AddCD Started***");
            Debug debug = new Debug();
            sb.Append(debug.printCDParams(CD));

            int retVal = -1;
			CD.itemNo_pk = CDs.GetHighestItemNo() + 1;
            sb.AppendLine("itemNo_pk [after new itemNo assigned]: " + CD.itemNo_pk.ToString());

            using (Media_Entity ctx = new Media_Entity())
			{
                try
                {
                    ctx.Media_Music_CDs.Add(CD);
                    ctx.SaveChanges();
                    retVal = (int)Convert.ToInt16(CD.itemNo_pk);
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in AddCD");
                    sb.AppendLine(ex.Message);
                    sb.AppendLine(ex.InnerException.StackTrace);
                    sb.AppendLine(ex.HResult.ToString());
                }				
			}            
            return retVal;
		}

		public static void DeleteCD(int ID)
		{
			using (Media_Entity ctx = new Media_Entity())
			{
				Media_Music_CDs ItemToDelete = ctx.Media_Music_CDs.Single((Media_Music_CDs x) => x.itemNo_pk == (decimal)ID);
				bool flag = ItemToDelete != null;
				if (flag)
				{
					ctx.Media_Music_CDs.Remove(ItemToDelete);
					ctx.SaveChanges();
				}
			}
		}

        public static int GetBindersCount()
        {
            int result;
            using (Media_Entity ctx = new Media_Entity())
            {
                result = ctx.Media_Music_CDs.Select(m => m.binder).Distinct().Count();
            }
            return result;
        }

		public static Media_Music_CDs GetCD(int ID)
		{
            StringBuilder sb = new StringBuilder();
			Media_Music_CDs returnValue = new Media_Music_CDs();
			using (Media_Entity ctx = new Media_Entity())
			{
                try
                {
                    returnValue = ctx.Media_Music_CDs.Single((Media_Music_CDs x) => x.itemNo_pk == (decimal)ID);
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in GetCD");
                    sb.AppendLine(ex.Message);
                }                
			}            
            return returnValue;
		}

		public static int GetCDsCount()
		{
			int result;
			using (Media_Entity ctx = new Media_Entity())
			{
				result = ctx.Media_Music_CDs.Count<Media_Music_CDs>();
			}
			return result;
		}
      
        public static int GetHighestItemNo()
        {
            int result;
            using (Media_Entity ctx = new Media_Entity())
            {
                result = ctx.Media_Music_CDs.Max(m => (int)m.itemNo_pk);
            }
            return result;
        }

		public static List<Media_Music_CDs> SearchCDs_NoFilter(int page)
		{
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_NoFilter started. page: " + page.ToString());
			List<Media_Music_CDs> returnValue = new List<Media_Music_CDs>();
			int RecordsToSkip = (page - 1) * Constants.PAGE_SIZE;
            sb.AppendLine("RecordsToSkip: " + RecordsToSkip.ToString());
			using (Media_Entity ctx = new Media_Entity())
			{
                try
                {
                    returnValue = ctx.Media_Music_CDs
                    .OrderBy(x => x.Artist)
                    .ThenBy(x => x.Title)
                    .Skip(0 <= RecordsToSkip ? RecordsToSkip : 0)
                    .Take(Constants.PAGE_SIZE)
                    .ToList<Media_Music_CDs>();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_NoFilter");
                    sb.AppendLine(ex.Message);
                }
				
			}            
            return returnValue;
		}
      
        public static List<Media_Music_CDs> SearchCDs_Artist(string artist, int page)
		{
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_Artist started. page: " + page.ToString() + " artist: " + artist);
            List<Media_Music_CDs> returnValue = new List<Media_Music_CDs>();
			int RecordsToSkip = (page - 1) * Constants.PAGE_SIZE;
            sb.AppendLine("RecordsToSkip: " + RecordsToSkip.ToString());
            using (Media_Entity ctx = new Media_Entity())
			{
                try
                {
                    returnValue = (from x in ctx.Media_Music_CDs
                                   where x.Artist.Contains(artist)
                                   select x)
                        .OrderBy(x => x.Artist)
                        .ThenBy(x => x.Title)
                        .Skip(0 <= RecordsToSkip ? RecordsToSkip : 0)
                        .Take(Constants.PAGE_SIZE)
                        .ToList<Media_Music_CDs>();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Artist");
                    sb.AppendLine(ex.Message);
                }
				
			}            
            return returnValue;
		}

        public static int SearchCDs_Artist_Count(string artist)
        {
            int result = -1;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_Artist_Count started." + " artist: " + artist);            
                        
            using (Media_Entity ctx = new Media_Entity())
            {
                try
                {
                    result = (from x in ctx.Media_Music_CDs
                                   where x.Artist.Contains(artist)
                                   select x).Count();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Artist_Count");
                    sb.AppendLine(ex.Message);
                }
            }                      
            return result;
        }

        public static List<Media_Music_CDs> SearchCDs_Title(string title, int page)
		{
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_Title started. page: " + page.ToString() + " title: " + title);
            List<Media_Music_CDs> returnValue = new List<Media_Music_CDs>();
			int RecordsToSkip = (page - 1) * Constants.PAGE_SIZE;
            sb.AppendLine("RecordsToSkip: " + RecordsToSkip.ToString());
            using (Media_Entity ctx = new Media_Entity())
			{
                try
                {
                    returnValue = (from x in ctx.Media_Music_CDs
                                   where x.Title.Contains(title)
                                   select x)
                        .OrderBy(x => x.Artist)
                        .ThenBy(x => x.Title)
                        .Skip(0 <= RecordsToSkip ? RecordsToSkip : 0)
                        .Take(Constants.PAGE_SIZE)
                        .ToList<Media_Music_CDs>();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Title");
                    sb.AppendLine(ex.Message);
                }
	
			}            
            return returnValue;
		}

        public static int SearchCDs_Title_Count(string title)
        {
            int result = -1;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_Title_Count started." + " title: " + title);

            using (Media_Entity ctx = new Media_Entity())
            {
                try
                {
                    result = (from x in ctx.Media_Music_CDs
                              where x.Title.Contains(title)
                              select x).Count();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Title_Count");
                    sb.AppendLine(ex.Message);
                }
            }            
            return result;
        }

        public static List<Media_Music_CDs> SearchCDs_Binder(int binderNo, int page)
		{
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_Binder started. page: " + page.ToString() + " binderNo: " + binderNo.ToString());
            List<Media_Music_CDs> returnValue = new List<Media_Music_CDs>();
			int RecordsToSkip = (page - 1) * Constants.PAGE_SIZE;
            sb.AppendLine("RecordsToSkip: " + RecordsToSkip.ToString());
            using (Media_Entity ctx = new Media_Entity())
			{
                try
                {
                    returnValue = (from x in ctx.Media_Music_CDs
                                   where x.binder == (decimal)binderNo
                                   select x)
                        .OrderBy(x => x.Artist)
                        .ThenBy(x => x.Title)
                        .Skip(0 <= RecordsToSkip ? RecordsToSkip : 0)
                        .Take(Constants.PAGE_SIZE)
                        .ToList<Media_Music_CDs>();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Binder");
                    sb.AppendLine(ex.Message);
                }

			}            
            return returnValue;
		}

        public static int SearchCDs_Binder_Count(int binderNo)
        {
            int result = -1;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SearchCDs_Binder_Count started." + " binderNo: " + binderNo.ToString());

            using (Media_Entity ctx = new Media_Entity())
            {
                try
                {
                    result = (from x in ctx.Media_Music_CDs
                              where x.binder == (decimal)binderNo
                              select x).Count();                     
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Binder_Count");
                    sb.AppendLine(ex.Message);
                }
            }            
            return result;
        }

        
        // http://stackoverflow.com/questions/6353350/multiple-where-conditions-in-ef
        public static List<Media_Music_CDs> SearchCDs_Advanced(SearchCDs_Advanced_Input input)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SearchCDs_Advanced started.");
            sb.AppendLine("input.Page: " + input.Page.ToString());
            sb.AppendLine("input.SearchCD: ");
            Debug debug = new Debug();
            sb.Append(debug.printCDParams(input.SearchCD));

            List<Media_Music_CDs> returnValue = new List<Media_Music_CDs>();
            int RecordsToSkip = (input.Page - 1) * Constants.PAGE_SIZE;
            sb.AppendLine("RecordsToSkip: " + RecordsToSkip.ToString());
            using (Media_Entity ctx = new Media_Entity())
            {
                try
                {
                    var query = (from x in ctx.Media_Music_CDs select x);
                    if (false == string.IsNullOrEmpty(input.SearchCD.Artist))
                    {
                        query = query.Where(c => c.Artist == input.SearchCD.Artist);
                    }
                    if (false == string.IsNullOrEmpty(input.SearchCD.Title))
                    {
                        query = query.Where(c => c.Title == input.SearchCD.Title);
                    }
                    if (0 < input.SearchCD.binder)
                    {
                        query = query.Where(c => c.binder == input.SearchCD.binder);
                    }
                    if (input.Filter_isMixed)
                    {
                        query = query.Where(c => c.isMixed == input.SearchCD.isMixed);
                    }
                    if (input.Filter_isSingle)
                    {
                        query = query.Where(c => c.isSingle == input.SearchCD.isSingle);
                    }
                    if (false == string.IsNullOrEmpty(input.SearchCD.misc))
                    {
                        query = query.Where(c => c.misc == input.SearchCD.misc);
                    }
                    if (0 < input.SearchCD.numDiscs)
                    {
                        query = query.Where(c => c.numDiscs == input.SearchCD.numDiscs);
                    }

                    returnValue = query
                        .OrderBy(x => x.Artist)
                        .ThenBy(x => x.Title)
                        .Skip(0 <= RecordsToSkip ? RecordsToSkip : 0)
                        .Take(Constants.PAGE_SIZE)
                        .ToList<Media_Music_CDs>();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Binder");
                    sb.AppendLine(ex.Message);
                }

            }
            //Debug_WriteLog(sb.ToString());
            return returnValue;
        }

        public static int SearchCDs_Advanced_Count(SearchCDs_Advanced_Input input)
        {
            int result = -1;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SearchCDs_Advanced_Count started.");

            using (Media_Entity ctx = new Media_Entity())
            {
                try
                {
                    var query = (from x in ctx.Media_Music_CDs select x);
                    if (false == string.IsNullOrEmpty(input.SearchCD.Artist))
                    {
                        query = query.Where(c => c.Artist == input.SearchCD.Artist);
                    }
                    if (false == string.IsNullOrEmpty(input.SearchCD.Title))
                    {
                        query = query.Where(c => c.Title == input.SearchCD.Title);
                    }
                    if (0 < input.SearchCD.binder)
                    {
                        query = query.Where(c => c.binder == input.SearchCD.binder);
                    }
                    if (input.Filter_isMixed)
                    {
                        query = query.Where(c => c.isMixed == input.SearchCD.isMixed);
                    }
                    if (input.Filter_isSingle)
                    {
                        query = query.Where(c => c.isSingle == input.SearchCD.isSingle);
                    }
                    if (false == string.IsNullOrEmpty(input.SearchCD.misc))
                    {
                        query = query.Where(c => c.misc == input.SearchCD.misc);
                    }
                    if (0 < input.SearchCD.numDiscs)
                    {
                        query = query.Where(c => c.numDiscs == input.SearchCD.numDiscs);
                    }

                    result = query.Count();
                }
                catch (Exception ex)
                {
                    sb.AppendLine("Error in SearchCDs_Binder");
                    sb.AppendLine(ex.Message);
                }
            }

            //Debug_WriteLog(sb.ToString());
            return result;
        }

        public static string UpdateCD(Media_Music_CDs CD)
		{
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("UpdateCD started.");
            sb.AppendLine("Input: ");
            Debug debug = new Debug();
            sb.Append(debug.printCDParams(CD));
            
            try
            {
                if (null == CD) { throw new Exception("null CD input"); }
                using (Media_Entity ctx = new Media_Entity())
                {
                    Media_Music_CDs ItemToUpdate = ctx.Media_Music_CDs.Single((Media_Music_CDs x) => x.itemNo_pk == CD.itemNo_pk);

                    sb.AppendLine("ItemToUpdate: ");
                    sb.Append(debug.printCDParams(ItemToUpdate));

                    if (null == ItemToUpdate) { throw new Exception("null record returned on UpdateCD"); }
                    ItemToUpdate.Artist = CD.Artist;
                    ItemToUpdate.binder = CD.binder;
                    ItemToUpdate.imageUrl_lg = CD.imageUrl_lg;
                    ItemToUpdate.imageUrl_sm = CD.imageUrl_sm;
                    ItemToUpdate.isMixed = CD.isMixed;
                    ItemToUpdate.isSingle = CD.isSingle;
                    ItemToUpdate.misc = CD.misc;
                    ItemToUpdate.numDiscs = CD.numDiscs;
                    ItemToUpdate.Title = CD.Title;
                    ctx.Entry<Media_Music_CDs>(ItemToUpdate).State = EntityState.Modified;
                    ctx.SaveChanges();
                }

                //Debug_WriteLog(sb.ToString());
                return "Success";
            }
			catch (Exception ex)
            {
                sb.AppendLine("Error in UpdateCD");
                sb.AppendLine(ex.Message);
                //Debug_WriteLog(sb.ToString());
                return ex.Message;
            }
		}

        public static void Debug_WriteLog(string message)
        {
            string filePath = "C:\\Logs\\CDServiceWCF_Debug.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(string.Format(message, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")));
                writer.Close();
                Console.WriteLine(message);
            }
        }
	}
}
