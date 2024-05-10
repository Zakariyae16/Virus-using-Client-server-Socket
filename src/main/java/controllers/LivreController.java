package controllers;

import dao.LivreDao;
import dao.LivreDaoImp;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import models.Livre;

import java.io.IOException;
import java.util.List;

@WebServlet(name = "livre", value = {"/livre", "/livre/add", "/livre/edit", "/livre/delete", "/livre/update"})
public class LivreController extends HttpServlet {
    private final String INDEX = "/WEB-INF/views/livre/index.jsp"; //create jsp file
    private final String CREATE = "/WEB-INF/views/livre/form.jsp";
    private final String EDIT = "/WEB-INF/views/livre/edit.jsp";
    private LivreDao dao = new LivreDaoImp();

    @Override
    protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String path = req.getServletPath();
        int id;
        switch (path) {
            case "/livre":
                List<Livre> livres = dao.getAll();
                req.setAttribute("list", livres); // set up (c: foreach
                req.getRequestDispatcher(INDEX).forward(req, resp);
                break;
            case "/livre/add":
                req.getRequestDispatcher(CREATE).forward(req, resp);
                break;
            case "/livre/delete":
                id = Integer.parseInt(req.getParameter("id"));
                dao.delete(id);
                resp.sendRedirect(req.getContextPath() + "/livre");
                break;
            case "/livre/edit":
                id = Integer.parseInt(req.getParameter("id"));
                Livre l = dao.getById(id);
                req.setAttribute("l", l);
                req.getRequestDispatcher(EDIT).forward(req, resp);
                break;
        }
    }
}
