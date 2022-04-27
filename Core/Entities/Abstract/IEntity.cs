namespace Core.Entities.Abstract
{
    public interface IEntity
    {
        /// <summary>
        /// Veritabanında karşılık gelen tablolarda olacak.
        /// </summary>
        int Id { get; set; }

        // İmza görevi görmektedir.
    }
}