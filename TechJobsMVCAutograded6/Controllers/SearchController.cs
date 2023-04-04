using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVCAutograded6.Data;
using TechJobsMVCAutograded6.Models;
using System.Diagnostics;

namespace TechJobsMVCAutograded6.Controllers;

public class SearchController : Controller
{

    // GET: /<controller>/
    
    
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.columns = ListController.ColumnChoices;
        //ViewBag.jobs = jobs ;
    
        return View();
    }

    // TODO #3 - Create an action method to process a search request and render the updated search views.
    [HttpPost]
    public IActionResult Results(string searchType, string searchTerm)
    {
        List<Job> jobs = new List<Job>();
        ViewBag.columns = ListController.ColumnChoices;
        ViewBag.title = "Jobs";

        if(searchTerm == "all" || searchTerm == null)
        {

                jobs = JobData.FindAll();
            ViewBag.jobs = jobs;

        }
        else
        {
            jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            ViewBag.jobs = jobs;
        }
         

        return View ("Index");
    }
}

