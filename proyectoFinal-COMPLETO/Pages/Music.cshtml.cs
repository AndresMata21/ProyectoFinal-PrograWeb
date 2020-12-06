using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoFinal.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace proyectoFinal.Pages
{
    public class MusicModel : PageModel
    {
        public string Message { get; set; }
        public List<Music> MusicList { get; set; }
        public readonly AppDbContext _db;

        public MusicModel(AppDbContext _db) {
            this._db = _db;
        }

        public void OnGet() {
            Message = "List of music";
            MusicList = _db.Musics.AsEnumerable().ToList();
        }

        public IActionResult OnPost(int songId)
        {
            Message = "List of Music";

            var song2Delete = _db.Musics.Find(songId);
            if (song2Delete != null)
            {
                _db.Remove(song2Delete);
            }

            _db.SaveChanges();
            MusicList = _db.Musics.AsEnumerable().ToList();
            return Page();
        }
    }
}
