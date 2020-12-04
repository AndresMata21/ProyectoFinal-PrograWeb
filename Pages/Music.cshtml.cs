using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyectoFinal.Model;
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
    }
}
