

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Investimentos.aspx.cs" Inherits="Wedify.Account.Investimentos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/custom-graph.js" type="text/javascript"></script>
    <div class="row">  
        <div class="panel-heading">  
            <div class="col-md-8">  
                <h3>  
                    <i class="fa fa-pie-chart"></i>  
                    <span>ASP.NET Webform - Google Graph Integration </span>  
                </h3>  
            </div>  
        </div>  
    </div>  
  
    <div class="row">  
        <section class="col-md-12 col-md-push-0">  
            <section>  
                <div class="well bs-component">  
                    <br />  
  
                    <div class="row">  
                        <div class="col-xs-12">  
                            <!-- CHART -->  
                            <div class="box box-primary">  
                                <div class="box-header with-border">  
                                    <h3 class="box-title custom-heading">Product wise Graph</h3>  
                                </div>  
                                <div class="box-body">  
                                    <div class="chart">  
                                        <div id="graphId" style="width: 1100px; height: 900px; margin:auto;"></div>  
                                    </div>  
                                </div><!-- /.box-body -->  
                            </div><!-- /.box -->  
                        </div>  
                    </div>  
                </div>  
            </section>  
        </section>  
    </div>  

</asp:Content>
