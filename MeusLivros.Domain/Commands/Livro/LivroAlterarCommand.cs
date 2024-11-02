﻿using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands.Livro
{
    public class LivroAlterarCommand : Notificavel, ICommand
    {
        public LivroAlterarCommand(int id, string nome, int autorId, int editoraId)
        {
            Id = id;
            Nome = nome;
            AutorId = autorId;
            EditoraId = editoraId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int AutorId { get; set; }
        public int EditoraId { get; set; }

        public void Validar()
        {
            if (Id == 0)
            {
                AddNotificacao("O código informado é inválido.");
            }
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNotificacao("O Nome do Livro é obrigátorio!");
            }
            if (AutorId == null)
            {
                AddNotificacao("Insira o Autor!");
            }
            if (EditoraId == null)
            {
                AddNotificacao("Insira a Editora!");
            }
        }
    }
}