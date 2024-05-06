namespace CamstarServiceClient.Service
{
    ///    @Description User Defined Codes are used to allow each customer to specify a list of allowable values for a specific field. In many cases a User Defined Code will merely consist of a Name and Description with no additional attributes. User Defined Codes can also have associated WIP Messages, if they are associated with a field from a Container Definition. They may also include additional attributes, typically used for additional validations.The name for each Code must be unique within its type. This value is used as an alternate key for lookup-up, data entry and validation.This document includes a section that describes each Type of User Defined Code delivered with Pajaro. Each type equates to a CDO Definition.
    ///    @author lichong
    ///    @date 2024/4/15
    public abstract class UserCodeWithWMRef: UserCodeRef
    {
        public UserCodeWithWMRef(string name) : base(name) { }
    }
}

