package Controllers;


import dao.LivreDao;
import dao.LivreDaoImp;
import dao.UsersDao;
import dao.UsersDaoImp;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import models.Livre;
import models.Users;

import java.io.IOException;
import java.util.List;

@WebServlet(name = "user", value = {"/user", "/user/add", "/livre/edit", "/livre/delete", "/livre/update"})
public class UsersController extends HttpServlet {
    private final String INDEX = "/WEB-INF/views/user/index.jsp"; //create jsp file
    private final String TEST= "/WEB-INF/views/librarian/index.jsp";
    private final String TESTFAUX = "/WEB-INF/views/user/testfaux.jsp";
    private UsersDao dao = new UsersDaoImp();




    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        if (req.getServletPath().equals("/user")) {
            String username = req.getParameter("login");
            String password = req.getParameter("pwd");

            Users user = dao.getByLogin(username, password);

            if (user != null) {
                HttpSession session = req.getSession();
                session.setAttribute("user", user);
//                session.getAttribute("user");
                if (user.getRole().equals("BIBLIOTHECAIRE")) {
                    //req.getRequestDispatcher(TEST).forward(req, resp);
                    resp.sendRedirect(req.getContextPath()+"/admin");
                } else {
                    req.getRequestDispatcher(TESTFAUX).forward(req, resp);
                }
            } else {
                req.setAttribute("errorMessage", "Invalid email or password");
                req.getRequestDispatcher(INDEX).forward(req, resp);
            }
        }
    }
}
