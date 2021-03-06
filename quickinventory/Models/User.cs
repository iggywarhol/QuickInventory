﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
//
using SimpleInventory.Helpers;
//
namespace SimpleInventory.Models
{
    public class User
    {
        [Key]
        public long ID { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        [Required]
        public string Username { get; set; }
        [Required]
        public bool WasDeleted { get; set; }
        [MaxLength(100)]
        public string PasswordHash { get; set; }
        [ForeignKey("UserPermission")]
        public long UserPermission_Id { get; set; }
        public UserPermission UserPermission { get; set; }
        [ForeignKey("Tenant")]
        public long? Tenant_ID { get; set; }
        public bbTenant Tenant { get; set; }
        [Required]
        public System.DateTime CreatedDate { get; set; }
        public static string HashPassword(string password)
        {
            var hasher = new SHA256Managed();
            var unhashed = System.Text.Encoding.Unicode.GetBytes(password);
            var hashed = hasher.ComputeHash(unhashed);
            return Convert.ToBase64String(hashed);
        }
        public void UpdatePassword(string password)
        {
            /*
            var dbHelper = new DatabaseHelper();
            using (var conn = dbHelper.GetDatabaseConnection())
            {
                using (var command = dbHelper.GetSQLiteCommand(conn))
                {
                    string update = "UPDATE Users SET PasswordHash = @password WHERE ID = @userID";
                    command.CommandText = update;
                    command.Parameters.AddWithValue("@password", HashPassword(password));
                    command.Parameters.AddWithValue("@userID", ID);
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
            */
        }
    }
}
