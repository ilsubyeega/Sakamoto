﻿using Sakamoto.Api;
using Sakamoto.Api.Chat;
using Sakamoto.Database;
using Sakamoto.Database.Models.Chat;
using Sakamoto.Enums.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sakamoto.Transformer.Chat
{
	public static class ChannelTransformer
	{
		public static JsonChannel ToJsonChannel(this DBChannel channel, int? user = null)
		{
			return new JsonChannel
			{
				ChannelId = channel.ChannelId,
				Name = channel.Name,
				Description = channel.Description,
				Icon = channel.GetIconUrl(user),
				Type = (ChannelType)channel.Type,
				IsModerated = channel.Morderated
			};
		}
		public static void SetLastRead(this JsonChannel channel, int id)
			=> channel.LastReadId = id;
		public static JsonChannel IncludeLastRead(this JsonChannel channel, DBUserChannel db)
		{
			channel.LastReadId = db.LastReadId;
			return channel;
		}
		public static JsonChannel IncludeMessages(this JsonChannel channel, DBMessage[] messages, MariaDBContext ctx = null)
		{
			if (messages == null) return channel;
			if (messages.Length > 0)
			{
				var lastmessage = messages[messages.Length - 1];
				channel.LastMessageId = lastmessage.MessageId;
			}
			else
				channel.LastMessageId = 0;
			
			var messagelist = new List<JsonMessage>();
			foreach (var a in messages)
			{
				var jsmg = a.ToJsonMessage();
				if (ctx != null)
				{
					var us = ctx.Users.FirstOrDefault(u => u.Id == a.UserId);
					if (us != null)
						jsmg.IncludeSender(us);
				}
				messagelist.Add(jsmg);
			}
				
			channel.RecentMessages = messagelist.ToArray();
			return channel;
		}
		public static JsonChannel IncludeUsers(this JsonChannel channel, int[] users)
		{
			channel.Users = users;
			return channel;
		}
	}
}
