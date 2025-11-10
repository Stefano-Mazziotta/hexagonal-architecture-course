using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainComponent.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int ItemId { get; private set; }
        public string Message { get; set; }
        public Note(int id, int itemId, string message)
        {
            validateMessage(message);

            Id = id;
            ItemId = itemId;
            Message = message;
        }

        public void UpdateMessage(string message)
        {
            validateMessage(message);
            Message = message;
        }

        private void validateMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("El mensaje es obligatorio.", nameof(message));
            }

            if (message.Length > 100)
            {
                throw new ArgumentException("El mensaje no puede superar los 100 caracteres.", nameof(message));
            }
        }

    }
}
