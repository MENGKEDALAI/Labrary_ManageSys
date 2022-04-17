using System;
using System.Collections.Generic;

namespace LibraryManager.BLL
{
    public sealed class MemberStore
    {
        public List<Member> members { get; set; }

        private static readonly MemberStore instance = new MemberStore();

        static MemberStore()
        {

        }

        private MemberStore()
        {
            members = new List<Member>();
        }

        public static MemberStore Instance
        {
            get
            {
                return instance;
            }
        }

        public List<Member> GetMembersByName(String name)
        {
            return members.FindAll(m => m.name == name);
        }

        public Member GetMembersByID(String id)
        {
            return members.Find(m => m.id == id);
        }
        public List<Member> GetMembersByNationality(String nationality)
        {
            return members.FindAll(m => m.nationality == nationality);
        }
        public List<Member> GetMembersByBirth(DateTime birthDate)
        {
            return members.FindAll(m => m.birthDate == birthDate);
        }

        public void AddNewMember(String id, String name, String nationality, DateTime birthDate)
        {
            if (!members.Exists(m => m.id == id))
            {
                Member member = new Member(id, name, nationality, birthDate);
                members.Add(member);
            }
        }

        public void RemoveMember(Member member)
        {
            if (members.Contains(member))
            {
                _ = members.Remove(member);
            }
        }
    }
}
