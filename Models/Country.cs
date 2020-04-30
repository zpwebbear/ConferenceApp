namespace ConferenceApp.Models
{
    public class Country : BaseReferenceModel
    {
        public string Name { get; set; }
        public string Iso { get; set; }
        public string Iso3 { get; set; }
        public int IsoNumeric { get; set; }
    }
}