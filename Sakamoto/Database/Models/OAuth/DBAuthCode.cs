﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sakamoto.Database.Models.OAuth
{
	[Table("oauth_auth_codes")]
	public class DBAuthCode
	{
		[Key]
		[Column("id")]
		public string Id { get; set; }
		[Column("user_id")]
		public int UserId { get; set; }
		[Column("client_id")]
		public int ClientId { get; set; }
		[Column("scopes")]
		public string Scopes { get; set; }
		[Column("revoked")]
		public bool Revoked { get; set; }
		[Column("created_at")]
		public int CreatedAt { get; set; }
		[Column("expires_at")]
		public int ExpiresAt { get; set; }
	}
}
