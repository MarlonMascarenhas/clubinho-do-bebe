using System;

namespace ClubinhoDoBebe.Domain.Models {
    public class Cliente:EntidadeBase {
        public string Name { set; get; }

        public string CPF { set; get; }

        public string Phone { set; get; }

    }
}
