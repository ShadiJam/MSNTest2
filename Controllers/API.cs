using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

[Route("/api/handle")]
public class HandleController : CRUDController<Handle> {
    public HandleController(IRepository<Handle> r) : base(r){}

    [HttpGet("search")]
    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(handle => 
            handle.Name.ToLower().IndexOf(term.ToLower()) != -1
        )));
    }
}

[Route("/api/chatroom")]
public class ChatroomController : CRUDController<Chatroom> {
    public ChatroomController(IRepository<Chatroom> r) : base(r){}
    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(chatroom => 
            chatroom.Title.ToLower().IndexOf(term.ToLower()) != -1
        )));
    }
}

[Route("/api/message")]
public class MessageController : CRUDController<Message> {
    public MessageController(IRepository<Message> r) : base(r){}

    public IActionResult Search([FromQuery]string term, int listId = -1){
        return Ok(r.Read(dbset => dbset.Where(message => 
            message.Text.ToLower().IndexOf(term.ToLower()) != -1
        )));
    }
}
