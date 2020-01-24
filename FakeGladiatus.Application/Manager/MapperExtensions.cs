using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FakeGladiatus.Application.Manager
{
   public static class MapperExtensions
    {
        public static Notification Build(this NotificationDbEntity notificationDbEntity)
        {
            Notification n = new Notification
            {
                Id = notificationDbEntity.Id,
                AttackerUser = Build(notificationDbEntity.AttackerUser),
                TargetUser = Build(notificationDbEntity.TargetUser),
                AttackerChar = Build(notificationDbEntity.AttackerChar),
                TargetChar = Build(notificationDbEntity.TargetChar),
                FightTime = notificationDbEntity.FightTime,
                IsRead = notificationDbEntity.IsRead
            };
            return n;
        }
        public static NotificationDbEntity Build(this Notification notificationDbEntity)
        {
            NotificationDbEntity n = new NotificationDbEntity
            {
                AttackerUser = Build(notificationDbEntity.AttackerUser),
                TargetUser = Build(notificationDbEntity.TargetUser),
                AttackerChar = Build(notificationDbEntity.AttackerChar),
                TargetChar = Build(notificationDbEntity.TargetChar),
                FightTime = notificationDbEntity.FightTime,
                IsRead = notificationDbEntity.IsRead
            };

            return n;
        }
        public static Character Build(this CharacterDbEntity characterDbEntity, bool includeUser = false)
        {
            Character character = new Character
            {
                Id = characterDbEntity.Id,
                Power = characterDbEntity.Power,
                Intelligence = characterDbEntity.Intelligence,
                Hp = characterDbEntity.Hp,
                Defense = characterDbEntity.Defense,
                Agility = characterDbEntity.Agility,
                Name = characterDbEntity.Name,
                Level = characterDbEntity.Level,
                Exp = characterDbEntity.Exp
            };
            if (includeUser == true)
            {
                character.User = Build(characterDbEntity.User);
            }
            return character;
        }
        public static CharacterDbEntity Build(this Character character, bool includeUser = false)
        {
            CharacterDbEntity characterDbEntity = new CharacterDbEntity
            {
                Id = character.Id,
                Power = character.Power,
                Intelligence = character.Intelligence,
                Hp = character.Hp,
                Defense = character.Defense,
                Agility = character.Agility,
                Name = character.Name,
                Level = character.Level,
                Exp = character.Exp

            };
            if (includeUser == true)
            {
                characterDbEntity.User = Build(character.User);
            }
            return characterDbEntity;
        }
        public static User Build(this UserDbEntity userDbEntity)
        {
            User u = new User
            {
                Email = userDbEntity.Email,
                Id = userDbEntity.Id,
                NickName = userDbEntity.NickName,
                UserName = userDbEntity.UserName,
                Characters = userDbEntity.Characters?.Select(x => Build(x)).ToList()
            };
            if (u.Characters != null)
            {
                foreach (var c in u.Characters)
                {
                    c.User = u;
                }
            }

            return u;
        }
        public static UserDbEntity Build(this User u)
        {
            UserDbEntity userDbEntity = new UserDbEntity
            {
                Email = u.Email,
                Id = u.Id,
                NickName = u.NickName,
                UserName = u.UserName,
                Characters = u.Characters?.Select(x => Build(x)).ToList()
            };
            if (userDbEntity.Characters != null)
            {
                foreach (var c in userDbEntity.Characters)
                {
                    c.User = userDbEntity;
                }
            }
            return userDbEntity;
        }
    }
}
