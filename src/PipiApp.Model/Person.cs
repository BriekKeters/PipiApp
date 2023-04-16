using System.ComponentModel.DataAnnotations;

namespace PipiApp.Models;
public enum ToiletPreference
{
    Sitting,
    Standing

}
public class Person:BaseAuditableEntity
{
    [Key]
    public Guid PublicId { get; private set; }
    public string Firstname { get; set; }
    public string LastName { get; set; }
    public ToiletPreference Preference{ get; set; }
    public string? Comments { get; set; }
    public string? LikedToilets { get; set; }
    public string? DislikedToilets { get; set; }
    public bool IsDeleted { get; private set; }

    public Person(){}

    public Person(string firstname, string lastname, ToiletPreference preference)
    {
        this.Firstname = firstname;
        this.LastName = lastname;
        this.Preference = preference;
    }

    public bool Equals(Person? other)
    {
        return this.PublicId == other?.PublicId;
    }
    public void Delete()
    {
        this.IsDeleted = true;
    }
    public void Update(string firstname, string lastname,ToiletPreference preference)
    {
        this.Firstname = firstname;
        this.LastName = lastname;
        this.Preference = preference;
    }
    void CreatePublicId()
    {
        this.PublicId = new Guid();
    }
    public void AddComment(string commentId)
    {
        if (Comments == null)
        {
            Comments = "";
        }
        Comments += commentId + ", ";
    }
    public void RemoveComment(string commentId)
    {
        if (Comments == null)
        {
            Comments = "";
        }
        if (Comments.Contains(commentId+", "))
        {
            Comments = Comments.Replace(commentId, "");
        }
    }
    public void AddLikedToilet(string recordId)
    {
        if (LikedToilets == null)
        {
            LikedToilets = "";
        }
        else if (LikedToilets.Contains(recordId + ", "))
        {
            return;
        }
        if (DislikedToilets!=null && DislikedToilets.Contains(recordId + ", "))
        {
            DislikedToilets = DislikedToilets.Replace(recordId + ", ", "");
        }
        LikedToilets += recordId + ", ";
    }
    public void AddDislikedToilet(string recordId)
    {
        if (DislikedToilets == null)
        {
            DislikedToilets = "";
        }
        else if (DislikedToilets.Contains(recordId + ", "))
        {
            return;
        }
        if (LikedToilets != null && LikedToilets.Contains(recordId + ", "))
        {
            LikedToilets = LikedToilets.Replace(recordId + ", ", "");
        }
        DislikedToilets += recordId + ", ";
    }
}
