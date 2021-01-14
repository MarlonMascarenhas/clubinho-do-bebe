using System;

namespace ClubinhoDoBebe.Domain.Models {
    public class Produto {

        public Guid Id { set; get; }
        
        public string Name { set; get; }

        public string Descricao { set; get; }

        public float Price { set; get; }

        public string Photo { set; get; }
    }

}
