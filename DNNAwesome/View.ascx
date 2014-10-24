<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="DNNAwesome.View" %>
<%@ register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.Web.Client.ClientResourceManagement" Assembly="DotNetNuke.Web.Client" %>

<dnn:DnnCssInclude runat="server" FilePath="DesktopModules/DNNAwesome/Styles/select2.css" />
<dnn:DnnCssInclude runat="server" FilePath="DesktopModules/DNNAwesome/Styles/DataTables/jquery.dataTables.min.css" />
<dnn:DnnCssInclude runat="server" FilePath="DesktopModules/DNNAwesome/Styles/DataTables/jquery.dataTables_themeroller.css" />
<dnn:DnnCssInclude runat="server" FilePath="DesktopModules/DNNAwesome/Styles/Gritter/jquery.gritter.css" />

<div class="row-fluid">
    <div class="span6">
        <div class="dnnForm">
            <div class="dnnFormItem">
                <dnn:label runat="server" controlname="Name" text="Name" HelpText="Customer Name"></dnn:label>
                <input id="Name" name="Name" type="text" />
            </div>            
            <div class="dnnFormItem">
                <dnn:label runat="server" controlname="Address" text="Address" HelpText="Customer Address"></dnn:label>
                <input id="Address" name="Address" type="text" />
            </div>
            <div class="dnnFormItem">
                <dnn:label runat="server" controlname="City" text="City" HelpText="Customer City"></dnn:label>
                <input id="City" name="City" type="text" />
            </div>
            <div class="dnnFormItem">
                <dnn:label runat="server" controlname="ZipCode" text="Zip Code" HelpText="Customer ZipCode"></dnn:label>
                <input id="ZipCode" name="ZipCode" type="text" />
            </div>
            <div class="dnnFormItem">
                <dnn:label runat="server" controlname="CustomerStatus" text="Status" HelpText="Customer Status"></dnn:label>
                <select id="Status" name="Status"></select>
            </div>
            <ul class="dnnActions dnnClear">
                <li>
                    <a id="Submit" title="Submit" class="dnnPrimaryAction" href="" onclick="submitData(); return false;">Submit</a></li>
                <li>
                    <a id="Cancel" class="dnnSecondaryAction" href="" onclick="clearForm(); return false;">Cancel</a></li>
            </ul>
        </div>
    </div>
    <div class="span6">
        <table id="Customers" class="table table-striped table-bordered table-hover">
        </table>
    </div>
</div>

<dnn:DnnJsInclude runat="server" FilePath="/DesktopModules/DNNAwesome/Scripts/select2.js" />
<dnn:DnnJsInclude runat="server" FilePath="/DesktopModules/DNNAwesome/Scripts/jquery.dataTables.min.js" />
<dnn:DnnJsInclude runat="server" FilePath="/DesktopModules/DNNAwesome/Scripts/jquery.gritter.min.js" />

<script type="text/javascript">

    var sf = getServicesFramework(); // Services Framework

    $(document).ready(function () {
        populateStatus();
        $("#Status").select2();
        populateCustomers();
        $('div.dataTables_length select').select2();
    });

    // Gets the services framework clientside object necessary for setting request headers
    function getServicesFramework() {
        return $.ServicesFramework(<%=ModuleId %>);
    }

    // Populates the status dropdown
    function populateStatus()
    {
        $.ajax({
            url: '/DesktopModules/DNNAwesomeService/API/Services/GetStatus',
            beforeSend: sf.setModuleHeaders,
            type: 'GET',
            async: false,
            dataType: 'json',
            success: function (response) {
                var html = "";
                $("#Status").html(html);

                $(response).each(function (i, item) {
                    html = '<option value="' + item.Value + '">' + item.Text + '</option>';
                    $("#Status").append(html);
                });
            }
        });
    }

    // Populates the customers tables
    function populateCustomers()
    {
        var campaignsTable = $('#Customers').dataTable({
            bServerSide: true,
            bProcessing: true,
            bAutoWidth: false,
            bDestroy: true,
            sServerMethod: "POST",
            sAjaxSource: '/DesktopModules/DNNAwesomeService/API/Services/GetCustomers',
            aaSorting: [[1, 'asc']],
            aoColumns: [
               { mData: "CustomerID", sTitle: "ID", iDataSort: 1 },
               { mData: "Name", sTitle: "Name", iDataSort: 2 },
               { mData: "Address", sTitle: "Address", sClass: "hidden-phone", iDataSort: 3 },
               { mData: "City", sTitle: "City", sClass: "hidden-phone", iDataSort: 4 },
               { mData: "ZipCode", sTitle: "Zip Code", sClass: "hidden-phone", iDataSort: 5 },
               { 
                   mData: "StatusID", sTitle: "Status", bSortable: false, iDataSort: 6, 
                   mRender: function (data, type, row) {                
                       if (row.StatusID === 1 ) {
                           return "Active";
                       }
                       else{
                           return "Deleted";
                       }
                   }}
            ]
        });
    };

    // Submit new customer form data
    function submitData()
    {
        var customerModel = {
            Name: $("#Name").val(),
            Address: $("#Address").val(),
            City: $("#City").val(),
            ZipCode: $("#ZipCode").val(),
            StatusID: $("#Status").val()
        };

        $.ajax({
            url: "/DesktopModules/DNNAwesomeService/API/Services/CreateCustomer",
            type: "POST",
            traditional: true,
            async: false,
            data: JSON.stringify(customerModel),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {

                // Clear form
                clearForm();

                // Refresh grid
                $("#Customers").dataTable().fnDraw();

                // Show Message;
                if (response != "") {
                    showMessage("Form Submission", "Customer data was not submitted. Please check DNN logs to see what happened.");
                }
                else {
                    showMessage("Form Submission", "Customer data was submitted successfully!");
                }   
            },
            error: function (response) {
                // Show Message;
                showMessage("Form Submission", "Customer data was not submitted. Please check DNN logs to see what happened.");
            }
        });
    }

    // Clears and resets form data
    function clearForm()
    {
        $("#Name").val("");
        $("#Address").val("");
        $("#City").val("");
        $("#ZipCode").val("");
        $("#Status").select2("val",1);
    }

    // Shows gritter message
    function showMessage(title, text)
    {
        $.gritter.add({
            'title': title,
            'text': text
        });
    }
</script>