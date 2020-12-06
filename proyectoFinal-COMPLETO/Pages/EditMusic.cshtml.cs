using proyectoFinal.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proyectoFinal.Pages
{
    public class EditMusicModel : PageModel
    {
        public string Message { get; set; }
        public Music Music { get; set; }
        public readonly AppDbContext _db;

        public EditMusicModel(AppDbContext _db)
        {
            this._db = _db;
        }

        public IActionResult OnGet(int id)
        {
            Music = _db.Musics.Find(id);
            Message = $"Editar {Music.Name}";
            return Page();
        }

        public IActionResult OnPost(int hiddenId,string inputName, string inputAlbum, string inputGenre, string inputArtist, string inputYear)
        {
            Music = _db.Musics.Find(hiddenId);
            
            Music.Name = inputName;
            Music.Album = inputAlbum;
            Music.Genre = inputGenre;
            Music.Year = inputYear;
            Music.Artist = inputArtist;

            _db.Musics.Update(Music);
            _db.SaveChanges();
            return Page();
        }
    }
}