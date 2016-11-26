var data = [
{
    "Id": "sdsdfsad", "EducationForm": "Денна", "OrderNumber": 1,
    "Subject": "ТКП", "DSD": "КН, 6.050101, ЕІ", "Course": 1,
    "CountStudent": 11, "GroupCode": 11,
    "PlannedLectures": 11, "DoneLectures": 11,
    "PlannedPract": 11, "DonePract": 11,
    "PlannedLaboratory": 11, "DoneLaboratory": 11,
    "PlannedSeminar": 11, "DoneSeminar": 11,
    "PlannedIndividual": 11, "DoneIndividual": 11,
    "PlannedConsultation": 11, "DoneConsultation": 11,
    "PlannedExamConsultation": 11, "DoneExamConsultation": 11,
    "PlannedCheckControl": 11, "DoneCheckControl": 11,
    "PlannedCheckLectureControl": 11, "DoneCheckLectureControl": 11,
    "PlannedEAT": 11, "DoneEAT": 11,
    "PlannedCGS": 11, "DoneCGS": 11,
    "PlannedCoursework": 11, "DoneCoursework": 11,
    "PlannedOffsetting": 11, "DoneOffsetting": 11,
    "PlannedSemestrExam": 11, "DoneSemestrExam": 11,
    "PlannedTrainingPract": 11, "DoneTrainingPract": 11,
    "PlannedStateExam": 11, "DoneStateExam": 11,
    "PlannedDiploma": 11, "DoneDiploma": 11,
    "PlannedPostgraduates": 11, "DonePostgraduates": 11,
    "PlannedTotal": 12, "DoneTotal": 12
}];
var colNames = [
    'Id',
    'Форма навчання',
    '№ п/п',
    'Назва навчальних дисциплін і видів навчальної роботи',
    'Напрям, спеціальність, факультет',
    'Курс навчання',
    'Кількість студентів',
    'Шифр груп (потоків)',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.',
    'пл.', 'вик.'
];

var editruleInteger = { required: true, integer: true, minValue: 0, maxValue: 500 };
var editruleLetters = { required: true, custom: true, custom_func: checkOnlyLetters };
var colModel = [
    { name: 'Id', index: 'Id', key: true, width: 25, hidden: true },
    { name: 'EducationForm', editable: true, index: 'EducationForm', width: 25, editrules: editruleLetters },
    { name: 'OrderNumber', index: 'OrderNumber', width: 20, editable: true, editrules: editruleInteger },
    { name: 'Subject', index: 'Subject', width: 35, editable: true, editrules: editruleLetters },
    { name: 'DSD', index: 'DSD', width: 60, editable: true, editrules: {required: true} },
    { name: 'Course', index: 'Course', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, edittype: 'select', editoptions: { value: { 1: '1', 2: '2', 3: '3', 4: '4', 5: '5', 6: '6' } } },
    { name: 'CountStudent', index: 'CountStudent', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, editrules: editruleInteger },
    { name: 'GroupCode', index: 'GroupCode', width: 20, editable: true, editrules: { required: true, custom: true, custom_func: checkGroupCode } },
    { name: 'PlannedLectures', index: 'PlannedLectures', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Читання лекцій (пл.)' }, editrules: editruleInteger },
    { name: 'DoneLectures', index: 'DoneLectures', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Читання лекцій (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedPract', index: 'PlannedPract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення практичних занять (пл.)' }, editrules: editruleInteger },
    { name: 'DonePract', index: 'DonePract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення практичних занять (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedLaboratory', index: 'PlannedLaboratory', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення лабораторних занять (пл.)' }, editrules: editruleInteger },
    { name: 'DoneLaboratory', index: 'DoneLaboratory', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення лабораторних занять (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedSeminar', index: 'PlannedSeminar', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення семінарських занять (пл.)' }, editrules: editruleInteger },
    { name: 'DoneSeminar', index: 'DoneSeminar', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення семінарських занять (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedIndividual', index: 'PlannedIndividual', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення індивідуальних занять (пл.)' }, editrules: editruleInteger },
    { name: 'DoneIndividual', index: 'DoneIndividual', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення індивідуальних занять (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedConsultation', index: 'PlannedConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення консультацій протягом семестру (пл.)' }, editrules: editruleInteger },
    { name: 'DoneConsultation', index: 'DoneConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення консультацій протягом семестру (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedExamConsultation', index: 'PlannedExamConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення екзаменаційних консультацій (пл.)' }, editrules: editruleInteger },
    { name: 'DoneExamConsultation', index: 'DoneExamConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення екзаменаційних консультацій (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedCheckControl', index: 'PlannedCheckControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення контрольних робіт, що виконують під час аудиторних занять (пл.)' }, editrules: editruleInteger },
    { name: 'DoneCheckControl', index: 'DoneCheckControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення контрольних робіт, що виконують під час аудиторних занять (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedCheckLectureControl', index: 'PlannedCheckLectureControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення контрольних робіт, що виконують під час самостійної роботи (пл.)' }, editrules: editruleInteger },
    { name: 'DoneCheckLectureControl', index: 'DoneCheckLectureControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення контрольних робіт, що виконують під час самостійної роботи (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedEAT', index: 'PlannedEAT', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Реферати, аналітичні огляди, переклади (пл.)' }, editrules: editruleInteger },
    { name: 'DoneEAT', index: 'DoneEAT', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Реферати, аналітичні огляди, переклади (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedCGS', index: 'PlannedCGS', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Розрахункові, графічні, розрахунково-графічні роботи (пл.)' }, editrules: editruleInteger },
    { name: 'DoneCGS', index: 'DoneCGS', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Розрахункові, графічні, розрахунково-графічні роботи (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedCoursework', index: 'PlannedCoursework', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Курсові проекти, роботи (пл.)' }, editrules: editruleInteger },
    { name: 'DoneCoursework', index: 'DoneCoursework', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Курсові проекти, роботи (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedOffsetting', index: 'PlannedOffsetting', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення заліку (пл.)' }, editrules: editruleInteger },
    { name: 'DoneOffsetting', index: 'DoneOffsetting', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення заліку (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedSemestrExam', index: 'PlannedSemestrExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення семестрових екзаменів (пл.)' }, editrules: editruleInteger },
    { name: 'DoneSemestrExam', index: 'DoneSemestrExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення семестрових екзаменів (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedTrainingPract', index: 'PlannedTrainingPract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Керівництво навчальною і виробничою практикою (пл.)' }, editrules: editruleInteger },
    { name: 'DoneTrainingPract', index: 'DoneTrainingPract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Керівництво навчальною і виробничою практикою (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedStateExam', index: 'PlannedStateExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення державних екзаменів (пл.)' }, editrules: editruleInteger },
    { name: 'DoneStateExam', index: 'DoneStateExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Проведення державних екзаменів (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedDiploma', index: 'PlannedDiploma', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Керівництво, консультування, рецензування та проведення захисту дипломних проектів (робіт) (пл.)' }, editrules: editruleInteger },
    { name: 'DoneDiploma', index: 'DoneDiploma', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Керівництво, консультування, рецензування та проведення захисту дипломних проектів (робіт) (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedPostgraduates', index: 'PlannedPostgraduates', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Керівництво аспірантами, здобувачами та стажуванням викладачів (пл.)' }, editrules: editruleInteger },
    { name: 'DonePostgraduates', index: 'DonePostgraduates', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right', editable: true, formoptions: { label: 'Керівництво аспірантами, здобувачами та стажуванням викладачів (вик.)' }, editrules: editruleInteger },
    { name: 'PlannedTotal', index: 'PlannedTotal', width: 20,  sorttype: 'integer', align: 'right', formoptions: { label: 'Усього (пл.)' }, formatter: function (cellvalue, options, rowObject) {
        return rowObject["PlannedLectures"] + rowObject["PlannedPract"] + rowObject["PlannedLaboratory"] + rowObject["PlannedSeminar"] + rowObject["PlannedIndividual"] + rowObject["PlannedConsultation"] + rowObject["PlannedExamConsultation"] + rowObject["PlannedCheckControl"] + rowObject["PlannedCheckLectureControl"] + rowObject["PlannedEAT"] + rowObject["PlannedCGS"] + rowObject["PlannedCoursework"] + rowObject["PlannedOffsetting"] + rowObject["PlannedSemestrExam"] + rowObject["PlannedTrainingPract"] + rowObject["PlannedStateExam"] + rowObject["PlannedDiploma"] + rowObject["PlannedPostgraduates"];} },
    {name: 'DoneTotal', index: 'DoneTotal', width: 20, sorttype: 'integer', align: 'right', formoptions: { label: 'Усього (вик.)' }, formatter: function (cellvalue, options, rowObject) {
        return rowObject["DoneLectures"] + rowObject["DonePract"] + rowObject["DoneLaboratory"] + rowObject["DoneSeminar"] + rowObject["DoneIndividual"] + rowObject["DoneConsultation"] + rowObject["DoneExamConsultation"] + rowObject["DoneCheckControl"] + rowObject["DoneCheckLectureControl"] + rowObject["DoneEAT"] + rowObject["DoneCGS"] + rowObject["DoneCoursework"] + rowObject["DoneOffsetting"] + rowObject["DoneSemestrExam"] + rowObject["DoneTrainingPract"] + rowObject["DoneStateExam"] + rowObject["DoneDiploma"] + rowObject["DonePostgraduates"];} }];

jQuery("#Training").jqGrid({
    url: 'GetPlanTrainingJobs',
    datatype: "json",
    method: 'POST',
    autowidth: true,
    colNames: colNames,
    colModel: colModel,
    rowNum: 50,
    rowTotal: 2000,
    rowList: [20, 30, 50],
    scroll: 1,
    loadonce: true,
    rownumbers: true,
    rownumWidth: 40,
    gridview: true,
    sortname: 'Id',
    pager: "#TrainingJob",
    viewrecords: true,
    sortorder: "asc",
    caption: "Навчальна робота",
    editurl: "EditPlanTrainingJobs",
    ondblClickRow: function (id) { 
        $("#Training").jqGrid('editRow', id, { 
            keys: true, 
            oneditfunc: function () { }, 
            successfunc: function (response, postdata) {
                $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid');
                return [true, "", 0];
            } 
        }); 
    },
});

  $("#Training").jqGrid('navGrid', '#TrainingJob', {
    search: true,
    searchtext: "Пошук",
    refresh: false,
    add: true,
    width: 1140,
    del: true,
    edit: false,
    view: false,
    viewtitle: "Вибір",
    addtext: "Додати",
    deltext: "Видалити"
},
    update("edit"),
    update("add"),
    update("del")
);
function update(act) {
    return {
        closeAfterAdd: true,
        closeAfterEdit: true,
        width: '100%',
        reloadAfterSubmit: true,
        drag: true,
        onclickSubmit: function (params) {
            var list = $("#Training");
            var selectedRow = list.getGridParam("selrow");
            var rowData = list.getRowData(selectedRow);
            if (act === "add")
                params.url = 'SavePlanTrainingJobs';
            else if (act === "del") {
                params.url = 'DeletePlanTrainingJobs';
                params.url = 'DeletePlanTrainingJobs';                
            }
        },
        afterSubmit: function (response, postdata) {
            $(this).jqGrid('setGridParam', { datatype: 'json' }).trigger('reloadGrid')
            return [true, "", 0]
        }
    };
};

jQuery("#Training").jqGrid('setGroupHeaders', {
    useColSpanStyle: true,
    groupHeaders: [
     { startColumnName: 'PlannedLectures', numberOfColumns: 2, titleText: '<div class="groupHeader">Читання лекцій</div>' },
     { startColumnName: 'PlannedPract', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення практичних занять</div>' },
     { startColumnName: 'PlannedLaboratory', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення лабораторних занять</div>' },
     { startColumnName: 'PlannedSeminar', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення семінарських занять</div>' },
     { startColumnName: 'PlannedIndividual', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення індивідуальних занять</div>' },
     { startColumnName: 'PlannedConsultation', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення консультацій протягом семестру</div>' },
     { startColumnName: 'PlannedExamConsultation', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення екзаменаційних консультацій</div>' },
     { startColumnName: 'PlannedCheckControl', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення контрольних робіт, що виконують під час аудиторних занять</div>' },
     { startColumnName: 'PlannedCheckLectureControl', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення контрольних робіт, що виконують під час самостійної роботи</div>' },
     { startColumnName: 'PlannedEAT', numberOfColumns: 2, titleText: '<div class="groupHeader">Реферати, аналітичні огляди, переклади</div>' },
     { startColumnName: 'PlannedCGS', numberOfColumns: 2, titleText: '<div class="groupHeader">Розрахункові, графічні, розрахунково-графічні роботи</div>' },
     { startColumnName: 'PlannedCoursework', numberOfColumns: 2, titleText: '<div class="groupHeader">Курсові проекти, роботи</div>' },
     { startColumnName: 'PlannedOffsetting', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення заліку</div>' },
     { startColumnName: 'PlannedSemestrExam', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення семестрових екзаменів</div>' },
     { startColumnName: 'PlannedTrainingPract', numberOfColumns: 2, titleText: '<div class="groupHeader">Керівництво навчальною і виробничою практикою</div>' },
     { startColumnName: 'PlannedStateExam', numberOfColumns: 2, titleText: '<div class="groupHeader">Проведення державних екзаменів</div>' },
     { startColumnName: 'PlannedDiploma', numberOfColumns: 2, titleText: '<div class="groupHeader">Керівництво, консультування, рецензування та проведення захисту дипломних проектів (робіт)</div>' },
     { startColumnName: 'PlannedPostgraduates', numberOfColumns: 2, titleText: '<div class="groupHeader">Керівництво аспірантами, здобувачами та стажуванням викладачів</div>' },
    { startColumnName: 'PlannedTotal', numberOfColumns: 2, titleText: '<div class="groupHeader">Усього</div>' }
    ]
});
var grid = jQuery('#Training');
var thd = $("thead:first", grid.hDiv).get(0);
for (var i = 48; i < 55; i++) {
    $("tr th:eq(" + (i + 1) + ") div", thd).addClass("rotate");
}
$(".ui-th-column-header").height("300px");


function checkOnlyLetters(value, colname) {
    var reg = new RegExp("^[а-яА-ЯёЁa-zA-Z\ \.\,\_\-]{2,}$");
    if (!reg.test(value))
        return [false, colname + ". Введіть тільки букви. Не менше 2-х."];
    else
        return [true, ""];
}

function checkGroupCode(value, colname) {
    var reg = new RegExp("^[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2}\.[0-9]{1,2}$");
    if (!reg.test(value))
        return [false, colname + ". Введіть коректно шифр групи. (Наприклад: 6.04.52.15.01)"];
    else
        return [true, ""];
}