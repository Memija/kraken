namespace KrakenLibrary.Enums
{
    /// <summary>
    /// status of order
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// order pending book entry
        /// </summary>
        pending = 1,

        /// <summary>
        /// open order
        /// </summary>
        open = 2,

        /// <summary>
        /// closed order
        /// </summary>
        closed = 3,

        /// <summary>
        /// order canceled
        /// </summary>
        canceled = 4,

        /// <summary>
        /// order expired
        /// </summary>
        expired = 5
    }
}
