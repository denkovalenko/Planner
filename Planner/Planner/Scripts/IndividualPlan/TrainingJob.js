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

var colModel = [
    { name: 'Id', index: 'Id', width: 25, hidden: true },
    { name: 'EducationForm', index: 'EducationForm', width: 25 },
    { name: 'OrderNumber', index: 'OrderNumber', width: 20 },
    { name: 'Subject', index: 'Subject', width: 35 },
    { name: 'DSD', index: 'DSD', width: 60 },
    { name: 'Course', index: 'Course', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'CountStudent', index: 'CountStudent', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'GroupCode', index: 'GroupCode', width: 20 },
    { name: 'PlannedLectures', index: 'PlannedLectures', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneLectures', index: 'DoneLectures', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedPract', index: 'PlannedPract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DonePract', index: 'DonePract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedLaboratory', index: 'PlannedLaboratory', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneLaboratory', index: 'DoneLaboratory', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedSeminar', index: 'PlannedSeminar', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneSeminar', index: 'DoneSeminar', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedIndividual', index: 'PlannedIndividual', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneIndividual', index: 'DoneIndividual', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedConsultation', index: 'PlannedConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneConsultation', index: 'DoneConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedExamConsultation', index: 'PlannedExamConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneExamConsultation', index: 'DoneExamConsultation', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedCheckControl', index: 'PlannedCheckControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneCheckControl', index: 'DoneCheckControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedCheckLectureControl', index: 'PlannedCheckLectureControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneCheckLectureControl', index: 'DoneCheckLectureControl', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedEAT', index: 'PlannedEAT', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneEAT', index: 'DoneEAT', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedCGS', index: 'PlannedCGS', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneCGS', index: 'DoneCGS', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedCoursework', index: 'PlannedCoursework', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneCoursework', index: 'DoneCoursework', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedOffsetting', index: 'PlannedOffsetting', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneOffsetting', index: 'DoneOffsetting', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedSemestrExam', index: 'PlannedSemestrExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneSemestrExam', index: 'DoneSemestrExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedTrainingPract', index: 'PlannedTrainingPract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneTrainingPract', index: 'DoneTrainingPract', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedStateExam', index: 'PlannedStateExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneStateExam', index: 'DoneStateExam', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedDiploma', index: 'PlannedDiploma', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneDiploma', index: 'DoneDiploma', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedPostgraduates', index: 'PlannedPostgraduates', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DonePostgraduates', index: 'DonePostgraduates', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'PlannedTotal', index: 'PlannedTotal', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' },
    { name: 'DoneTotal', index: 'DoneTotal', width: 20, formatter: 'integer', sorttype: 'integer', align: 'right' }
];

jQuery("#Training").jqGrid({
    data: data,
    datatype: "local",
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
    ondblClickRow: function (id) {
        $("#Training").jqGrid('editRow', id, {
            keys: true,
            oneditfunc: function () { },
        });
    }
});

$("#Training").jqGrid('navGrid', '#TrainingJob', {

    search: true,
    searchtext: "Пошук",
    refresh: false,
    add: true,
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
function update(act) { }



//jQuery("#scroll37").jqGrid('navGrid', '#pscroll37', { del: false, add: false, edit: false }, {}, {}, {}, { multipleSearch: true });
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