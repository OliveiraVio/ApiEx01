﻿using AtvApi01.Enums;

namespace AtvApi01.Models
{
    public class PedidosModel
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public string EnderecoEntrega { get; set; }
        public StatusPedido Status { get; set; }
        public string MetodoPagamento { get; set; }
    }
}



