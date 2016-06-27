
function callNotify(pText, pType, pPlace) {
//Types: success, danger, info
    $.bootstrapGrowl(pText, {
        type: pType,
        align: pPlace,
        width: 'auto',
        allow_dismiss: false
    });
}