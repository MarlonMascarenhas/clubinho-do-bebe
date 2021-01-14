using System;

namespace ClubinhoDoBebe.Domain.Models {
    public abstract class EntidadeBase {
        public Guid Id { set; get; }

        public DateTime DataCriacao { set; get; }
    }
}
