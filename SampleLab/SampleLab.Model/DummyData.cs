using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLab.Model
{
    public class DummyData
    {
        public static List<Engagement> GetDummyData()
        {
            List<Engagement> engagementList = new List<Engagement>();

            engagementList.Add(new Engagement
            {
                ClientName = "CoCa Cola",
                WorkspaceName = "Atlanta Bottling & Distribution 2014",
                Name = "Q1 Quarterly Report 2014",
                Tasks = new List<EngagementTask>
                {
                    new EngagementTask{
                        New = true,
                        Name="ThumsUp Task 1",
                        DueDate=Convert.ToDateTime("18 Aug 2014"),
                        Phase = "1",
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Plan analyzed from Client.docx",
                            },
                            new Evidence{
                                Name="Q1Earning Lorem sum.pdf",
                            }
                        },
                    },
                    new EngagementTask{
                        Name="Double Check with Jim in ",
                        DueDate=Convert.ToDateTime("5 Feb 2015"),
                        Phase = "1",
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Plan analyzed from Client.docx",
                            },
                            new Evidence{
                                Name="Q1Earning Lorem sum.pdf",
                            }
                        },
                    },
                    new EngagementTask{
                        Name="Schedule Walk ",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Phase = "2",
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Plan analyzed from Client.docx",
                            },
                            new Evidence{
                                Name="Q1Earning Lorem sum 2013.pdf",
                            }
                        },
                    }
                },

            });
            engagementList.Add(new Engagement
            {
                ClientName = "CoCa Cola",
                WorkspaceName = "Asia Bottling & Distribution 2015",
                Name = "Q2 Quarterly Report 2015",
                Tasks = new List<EngagementTask>
                {
                    new EngagementTask{
                        New = true,
                        Name="ThumsUp Task 2",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q2 Earning Lorem sum.pdf",
                            }
                        },
                    },
                }
            });
            engagementList.Add(new Engagement
            {
                ClientName = "CoCa Cola",
                WorkspaceName = "Asia Bottling & Distribution 2015",
                Name = "Q3 Quarterly Report 2015",
                Tasks = new List<EngagementTask>
                {
                    new EngagementTask{
                        Name="ThumsUp Task 1",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q3 Earning Lorem sum.pdf",
                            }
                        },
                    },
                        new EngagementTask{
                        Name="Task Name Lorem Elit Bibendum Til Tellus Lorem Elit Bibendum",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q3 Earning Lorem sum.pdf",
                            }
                        },
                    },
                }
            });
            engagementList.Add(new Engagement
            {
                ClientName = "CoCa Cola",
                WorkspaceName = "Asia Bottling & Distribution 2015",
                Name = "Q4 Quarterly Report 2015",
                Tasks = new List<EngagementTask>
                {
                    new EngagementTask{
                        Name="ThumsUp Task 1",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q4 Earning Lorem sum.pdf",
                            }
                        },
                    },
                        new EngagementTask{
                        Name="ThumsUp Task 2",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q4 Earning Lorem sum.pdf",
                            }
                        },
                    },
                }
            });
            engagementList.Add(new Engagement
            {
                ClientName = "ThumsUp",
                WorkspaceName = "Indian Bottling & Distribution 2015",
                Name = "Q1 Quarterly Report 2015",
                Tasks = new List<EngagementTask>
                {
                    new EngagementTask{
                        Name="ThumsUp Task 1",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q1 Earning Lorem sum.pdf",
                            }
                        },
                    },
                        new EngagementTask{
                        Name="ThumsUp Task 2",
                        DueDate=Convert.ToDateTime("18 Aug 2015"),
                        Evidences=new List<Evidence>{
                            new Evidence{
                                Name="Sample file for engagement.docx",
                            },
                            new Evidence{
                                Name="Q1 Earning Lorem sum.pdf",
                            }
                        },
                    },
                }
            });
            var engageList = (from task in engagementList
                              select task).ToList();
            return engageList;
        }
    }
}
