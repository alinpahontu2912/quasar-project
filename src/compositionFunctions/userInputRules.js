export const dateRules = [val => !!val || '* Camp obligatoriu']
export const textRules = [val => !!val || '* Camp obligatoriu', val => val.length > 2 || 'Nume prea scurt']
