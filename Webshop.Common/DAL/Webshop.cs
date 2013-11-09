namespace Webshop.Common.DAL
{
    public partial class WebshopDataContext: Webshop.Common.DAL.IDAL
    {
        partial void OnCreated()
        {
           
        }

        public void SaveChanges()
        {
            this.SubmitChanges();
        }

    }
}
