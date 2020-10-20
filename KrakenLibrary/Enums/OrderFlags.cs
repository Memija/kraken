namespace KrakenLibrary.Enums
{
    /// <summary>
    /// comma delimited list of order flags
    /// </summary>
    public enum OrderFlags
    {
        /// <summary>
        /// volume in quote currency
        /// </summary>
        viqc = 1,

        /// <summary>
        /// prefer fee in base currency(default if selling)
        /// </summary>
        fcib = 2,

        /// <summary>
        /// prefer fee in quote currency(default if buying)
        /// </summary>
        fciq = 3,

        /// <summary>
        /// no market price protection
        /// </summary>
        nompp = 4,

        /// <summary>
        /// post only order(available when ordertype = limit)
        /// </summary>
        post = 5
    }
}
